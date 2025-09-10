using System;
using System.Collections.Generic;

namespace Municipality_App.Models
{
    public class UserProfile
    {
        public int Points { get; set; }
        public List<IssueReport> SubmittedIssues { get; set; } = new List<IssueReport>();
        public List<string> UnlockedBadges { get; set; } = new List<string>();
        public List<EngagementActivity> Activities { get; set; } = new List<EngagementActivity>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastActivityAt { get; set; } = DateTime.Now;
    }

    public class EngagementActivity
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public int PointsEarned { get; set; }
        public string Description { get; set; }
        public Guid? RelatedIssueId { get; set; }
    }
}
