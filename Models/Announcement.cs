using System;
using System.Collections.Generic;

namespace Municipality_App.Models
{
    public enum AnnouncementStatus
    {
        Sent,
        Pending,
    }

    public class Announcement
    {
        public Guid AnnouncementId { get; set; } = Guid.NewGuid();
        public string AnnouncementTitle { get; set; }
        public string AnnouncementDescription { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public string AnnouncementLocation { get; set; }
        public string AnnouncementCategory { get; set; }
        public AnnouncementStatus AnnouncementStatus { get; set; }
    }
}
