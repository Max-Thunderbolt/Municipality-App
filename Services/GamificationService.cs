using System;
using System.IO;
using Municipality_App.Models;
using Municipality_App.Structures;
using Newtonsoft.Json;

namespace Municipality_App.Services
{
    public static class GamificationService
    {
        private static readonly string StorageFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MunicipalityApp",
            "user_profile.json"
        );

        private static UserProfile _profile;

        public static void Initialize()
        {
            if (_profile != null)
            {
                return;
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(StorageFilePath));
                if (File.Exists(StorageFilePath))
                {
                    var json = File.ReadAllText(StorageFilePath);
                    _profile = JsonConvert.DeserializeObject<UserProfile>(json);

                    if (_profile == null)
                    {
                        var oldFilePath = StorageFilePath.Replace(".json", ".txt");
                        if (File.Exists(oldFilePath))
                        {
                            var text = File.ReadAllText(oldFilePath).Trim();
                            if (int.TryParse(text, out int points) && points >= 0)
                            {
                                _profile = new UserProfile { Points = points };
                                File.Delete(oldFilePath);
                            }
                        }
                    }
                }
            }
            catch { }

            if (_profile == null)
            {
                _profile = new UserProfile { Points = 0 };
                Persist();
            }
        }

        public static int Points
        {
            get
            {
                EnsureInitialized();
                return _profile.Points;
            }
        }

        public static UserProfile GetProfile()
        {
            EnsureInitialized();
            return _profile;
        }

        public static void AddPoints(
            int pointsToAdd,
            string reason = null,
            string activityType = null,
            Guid? relatedIssueId = null
        )
        {
            EnsureInitialized();
            if (pointsToAdd <= 0)
            {
                return;
            }
            checked
            {
                _profile.Points += pointsToAdd;
            }

            // Record activity
            var activity = new EngagementActivity
            {
                Type = activityType ?? "general",
                PointsEarned = pointsToAdd,
                Description = reason ?? "Points earned",
                RelatedIssueId = relatedIssueId,
            };
            _profile.Activities.Add(activity);
            _profile.LastActivityAt = DateTime.Now;

            // Check for new badges and achievements
            CheckAndUnlockBadges();
            CheckAndUnlockAchievements();

            Persist();
        }

        public static void AddIssue(IssueReport issue)
        {
            EnsureInitialized();
            _profile.SubmittedIssues.Add(issue);
            _profile.LastActivityAt = DateTime.Now;
            Persist();
        }

        public static int GetLevel()
        {
            EnsureInitialized();
            return Math.Max(1, (_profile.Points / 100) + 1);
        }

        public static string GetCurrentBadge()
        {
            EnsureInitialized();
            var p = _profile.Points;
            if (p >= 500)
                return "Community Leader";
            if (p >= 250)
                return "Engaged Citizen";
            if (p >= 100)
                return "Active Participant";
            return "Newcomer";
        }

        public static string[] GetUnlockedBadges()
        {
            EnsureInitialized();
            return _profile.UnlockedBadges.ToArray();
        }

        private static void CheckAndUnlockBadges()
        {
            if (!_profile.UnlockedBadges.Contains("First Steps") && _profile.Points >= 10)
                _profile.UnlockedBadges.Add("First Steps");

            if (!_profile.UnlockedBadges.Contains("Active Participant") && _profile.Points >= 100)
                _profile.UnlockedBadges.Add("Active Participant");

            if (!_profile.UnlockedBadges.Contains("Engaged Citizen") && _profile.Points >= 250)
                _profile.UnlockedBadges.Add("Engaged Citizen");

            if (!_profile.UnlockedBadges.Contains("Community Leader") && _profile.Points >= 500)
                _profile.UnlockedBadges.Add("Community Leader");

            if (
                !_profile.UnlockedBadges.Contains("Issue Reporter")
                && _profile.SubmittedIssues.Count >= 1
            )
                _profile.UnlockedBadges.Add("Issue Reporter");

            if (
                !_profile.UnlockedBadges.Contains("Dedicated Reporter")
                && _profile.SubmittedIssues.Count >= 5
            )
                _profile.UnlockedBadges.Add("Dedicated Reporter");

            if (
                !_profile.UnlockedBadges.Contains("Community Champion")
                && _profile.SubmittedIssues.Count >= 10
            )
                _profile.UnlockedBadges.Add("Community Champion");

            int eventCount = 0;
            foreach (var activity in _profile.Activities)
            {
                if (activity.Type == "event_attended")
                {
                    eventCount++;
                }
            }
            if (!_profile.UnlockedBadges.Contains("Event Attendee") && eventCount >= 1)
                _profile.UnlockedBadges.Add("Event Attendee");

            if (!_profile.UnlockedBadges.Contains("Regular Attendee") && eventCount >= 3)
                _profile.UnlockedBadges.Add("Regular Attendee");

            int announcementCount = 0;
            foreach (var activity in _profile.Activities)
            {
                if (activity.Type == "announcement_read")
                {
                    announcementCount++;
                }
            }
            if (!_profile.UnlockedBadges.Contains("Informed Citizen") && announcementCount >= 5)
                _profile.UnlockedBadges.Add("Informed Citizen");

            if (!_profile.UnlockedBadges.Contains("Well Informed") && announcementCount >= 10)
                _profile.UnlockedBadges.Add("Well Informed");
        }

        // New methods for enhanced engagement features
        public static void RecordFormCompletion(string formType)
        {
            EnsureInitialized();
            _profile.FormCompletions++;

            // Award points for form completion
            int points = 5; // default
            if (formType.ToLower() == "issue_report")
                points = 15;
            else if (formType.ToLower() == "event_registration")
                points = 10;
            else if (formType.ToLower() == "feedback")
                points = 5;

            AddPoints(points, $"Completed {formType} form", "form_completion");
        }

        public static void RecordSocialShare(string platform, string content, string shareType)
        {
            EnsureInitialized();
            _profile.SocialSharesCount++;

            var share = new SocialShare
            {
                Id = Guid.NewGuid().ToString(),
                Platform = platform,
                Content = content,
                SharedAt = DateTime.Now,
                PointsEarned = 10,
                ShareType = shareType,
            };

            _profile.SocialShares.Add(share);
            AddPoints(10, $"Shared on {platform}", "social_share");
        }

        public static void ParticipateInChallenge(string challengeId)
        {
            EnsureInitialized();
            _profile.ChallengeParticipations++;

            // Find the challenge and add to participated challenges
            CommunityChallenge challenge = null;
            var activeChallenges = GetActiveChallenges();
            foreach (var activeChallenge in activeChallenges)
            {
                if (activeChallenge.Id == challengeId)
                {
                    challenge = activeChallenge;
                    break;
                }
            }
            if (challenge != null)
            {
                _profile.ParticipatedChallenges.Add(challenge);
                AddPoints(
                    challenge.PointsReward,
                    $"Participated in challenge: {challenge.Title}",
                    "challenge_participation"
                );
            }
        }

        public static CustomList<CommunityChallenge> GetActiveChallenges()
        {
            return new CustomList<CommunityChallenge>
            {
                new CommunityChallenge
                {
                    Id = "weekly_engagement",
                    Title = "Weekly Engagement Champion",
                    Description = "Complete 5 different activities this week",
                    StartDate = DateTime.Now.AddDays(-7),
                    EndDate = DateTime.Now.AddDays(7),
                    PointsReward = 50,
                    Category = "Engagement",
                    IsActive = true,
                    Requirements = new CustomList<string>
                    {
                        "Report an issue",
                        "Register for an event",
                        "Read 3 announcements",
                        "Share content",
                        "Complete a form",
                    },
                },
                new CommunityChallenge
                {
                    Id = "community_helper",
                    Title = "Community Helper",
                    Description = "Submit 3 issue reports this month",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(30),
                    PointsReward = 75,
                    Category = "Community Service",
                    IsActive = true,
                    Requirements = new CustomList<string>
                    {
                        "Submit 3 issue reports",
                        "Get 1 issue resolved",
                    },
                },
                new CommunityChallenge
                {
                    Id = "social_advocate",
                    Title = "Social Media Advocate",
                    Description = "Share 5 pieces of content this month",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(30),
                    PointsReward = 40,
                    Category = "Social",
                    IsActive = true,
                    Requirements = new CustomList<string>
                    {
                        "Share 5 pieces of content",
                        "Use hashtag #MunicipalityApp",
                    },
                },
            };
        }

        private static void CheckAndUnlockAchievements()
        {
            // Form completion achievements
            if (!HasAchievement("Form Master") && _profile.FormCompletions >= 10)
                UnlockAchievement("Form Master", "Complete 10 forms", "📝", 100, "Forms");

            if (!HasAchievement("Form Expert") && _profile.FormCompletions >= 25)
                UnlockAchievement("Form Expert", "Complete 25 forms", "📋", 250, "Forms");

            // Social sharing achievements
            if (!HasAchievement("Social Butterfly") && _profile.SocialSharesCount >= 5)
                UnlockAchievement(
                    "Social Butterfly",
                    "Share 5 pieces of content",
                    "🦋",
                    50,
                    "Social"
                );

            if (!HasAchievement("Community Influencer") && _profile.SocialSharesCount >= 20)
                UnlockAchievement(
                    "Community Influencer",
                    "Share 20 pieces of content",
                    "📢",
                    200,
                    "Social"
                );

            // Challenge participation achievements
            if (!HasAchievement("Challenge Seeker") && _profile.ChallengeParticipations >= 3)
                UnlockAchievement(
                    "Challenge Seeker",
                    "Participate in 3 challenges",
                    "🏆",
                    75,
                    "Challenges"
                );

            if (!HasAchievement("Challenge Champion") && _profile.ChallengeParticipations >= 10)
                UnlockAchievement(
                    "Challenge Champion",
                    "Participate in 10 challenges",
                    "👑",
                    300,
                    "Challenges"
                );

            // Points-based achievements
            if (!HasAchievement("Point Collector") && _profile.Points >= 1000)
                UnlockAchievement("Point Collector", "Earn 1000 points", "💎", 500, "Points");

            if (!HasAchievement("Point Master") && _profile.Points >= 5000)
                UnlockAchievement("Point Master", "Earn 5000 points", "💫", 1000, "Points");
        }

        private static bool HasAchievement(string achievementName)
        {
            foreach (var achievement in _profile.Achievements)
            {
                if (achievement.Name == achievementName && achievement.IsUnlocked)
                {
                    return true;
                }
            }
            return false;
        }

        private static void UnlockAchievement(
            string name,
            string description,
            string icon,
            int pointsRequired,
            string category
        )
        {
            var achievement = new Achievement
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Description = description,
                Icon = icon,
                PointsRequired = pointsRequired,
                UnlockedAt = DateTime.Now,
                IsUnlocked = true,
                Category = category,
            };

            _profile.Achievements.Add(achievement);
        }

        public static CustomList<Achievement> GetUnlockedAchievements()
        {
            EnsureInitialized();
            var result = new CustomList<Achievement>();
            foreach (var achievement in _profile.Achievements)
            {
                if (achievement.IsUnlocked)
                {
                    result.Add(achievement);
                }
            }
            return result;
        }

        public static CustomList<Achievement> GetAllAchievements()
        {
            EnsureInitialized();
            return _profile.Achievements.ToList();
        }

        private static void Persist()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(StorageFilePath));
                var json = JsonConvert.SerializeObject(_profile, Formatting.Indented);
                File.WriteAllText(StorageFilePath, json);
            }
            catch { }
        }

        private static void EnsureInitialized()
        {
            if (_profile == null)
            {
                Initialize();
            }
        }
    }
}
