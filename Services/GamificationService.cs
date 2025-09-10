using System;
using System.IO;
using System.Linq;
using Municipality_App.Models;
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

                    // Handle migration from old text file format
                    if (_profile == null)
                    {
                        // Try to read old format
                        var oldFilePath = StorageFilePath.Replace(".json", ".txt");
                        if (File.Exists(oldFilePath))
                        {
                            var text = File.ReadAllText(oldFilePath).Trim();
                            if (int.TryParse(text, out int points) && points >= 0)
                            {
                                _profile = new UserProfile { Points = points };
                                File.Delete(oldFilePath); // Remove old file
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

            // Check for new badges
            CheckAndUnlockBadges();

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
            // Simple leveling: every 100 points is a level
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
            // Check point-based badges
            if (!_profile.UnlockedBadges.Contains("First Steps") && _profile.Points >= 10)
                _profile.UnlockedBadges.Add("First Steps");

            if (!_profile.UnlockedBadges.Contains("Active Participant") && _profile.Points >= 100)
                _profile.UnlockedBadges.Add("Active Participant");

            if (!_profile.UnlockedBadges.Contains("Engaged Citizen") && _profile.Points >= 250)
                _profile.UnlockedBadges.Add("Engaged Citizen");

            if (!_profile.UnlockedBadges.Contains("Community Leader") && _profile.Points >= 500)
                _profile.UnlockedBadges.Add("Community Leader");

            // Check issue-based badges
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

            // Check event-based badges
            var eventCount = _profile.Activities.Count(a => a.Type == "event_attended");
            if (!_profile.UnlockedBadges.Contains("Event Attendee") && eventCount >= 1)
                _profile.UnlockedBadges.Add("Event Attendee");

            if (!_profile.UnlockedBadges.Contains("Regular Attendee") && eventCount >= 3)
                _profile.UnlockedBadges.Add("Regular Attendee");

            // Check announcement-based badges
            var announcementCount = _profile.Activities.Count(a => a.Type == "announcement_read");
            if (!_profile.UnlockedBadges.Contains("Informed Citizen") && announcementCount >= 5)
                _profile.UnlockedBadges.Add("Informed Citizen");

            if (!_profile.UnlockedBadges.Contains("Well Informed") && announcementCount >= 10)
                _profile.UnlockedBadges.Add("Well Informed");
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
