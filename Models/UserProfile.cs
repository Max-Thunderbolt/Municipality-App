using System;
using Municipality_App.Structures;

namespace Municipality_App.Models
{
    public class UserProfile
    {
        public int Points { get; set; }
        public CustomList<IssueReport> SubmittedIssues { get; set; } =
            new CustomList<IssueReport>();
        public CustomList<string> UnlockedBadges { get; set; } = new CustomList<string>();
        public CustomList<EngagementActivity> Activities { get; set; } =
            new CustomList<EngagementActivity>();
        public CustomList<Achievement> Achievements { get; set; } = new CustomList<Achievement>();
        public CustomList<CommunityChallenge> ParticipatedChallenges { get; set; } =
            new CustomList<CommunityChallenge>();
        public CustomList<SocialShare> SocialShares { get; set; } = new CustomList<SocialShare>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastActivityAt { get; set; } = DateTime.Now;
        public int FormCompletions { get; set; } = 0;
        public int SocialSharesCount { get; set; } = 0;
        public int ChallengeParticipations { get; set; } = 0;
    }

    public class EngagementActivity
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public int PointsEarned { get; set; }
        public string Description { get; set; }
        public Guid? RelatedIssueId { get; set; }
    }

    public class Achievement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int PointsRequired { get; set; }
        public DateTime UnlockedAt { get; set; }
        public bool IsUnlocked { get; set; }
        public string Category { get; set; }
    }

    public class CommunityChallenge
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PointsReward { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public int ParticipantCount { get; set; }
        public CustomList<string> Requirements { get; set; } = new CustomList<string>();
    }

    public class SocialShare
    {
        public string Id { get; set; }
        public string Platform { get; set; }
        public string Content { get; set; }
        public DateTime SharedAt { get; set; }
        public int PointsEarned { get; set; }
        public string ShareType { get; set; }
    }
}
