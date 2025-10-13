using System;
using System.Collections.Generic;
using System.Linq;
using Municipality_App.Models;

namespace Municipality_App.Services
{
    public static class AnnouncementService
    {
        // Hash Table for quick announcement lookup by category
        private static readonly Dictionary<string, List<Announcement>> _announcementsByCategory =
            new Dictionary<string, List<Announcement>>();

        // Hash Table for quick announcement lookup by ID
        private static readonly Dictionary<Guid, Announcement> _announcementLookup =
            new Dictionary<Guid, Announcement>();

        // Sorted Dictionary for announcements sorted by date
        private static readonly SortedDictionary<
            DateTime,
            List<Announcement>
        > _announcementsByDate = new SortedDictionary<DateTime, List<Announcement>>();

        // Set for tracking announcement categories
        private static readonly HashSet<string> _announcementCategories = new HashSet<string>();

        // Queue for announcement delivery
        private static readonly Queue<Announcement> _announcementQueue = new Queue<Announcement>();

        static AnnouncementService()
        {
            InitializeSampleAnnouncements();
        }

        private static void InitializeSampleAnnouncements()
        {
            var sampleAnnouncements = new List<Announcement>
            {
                new Announcement
                {
                    AnnouncementTitle = "Road Maintenance Schedule",
                    AnnouncementDescription =
                        "Road maintenance will be conducted on Main Street from 8 AM to 5 PM on weekdays",
                    AnnouncementDate = DateTime.Now.AddDays(-2),
                    AnnouncementLocation = "Main Street",
                    AnnouncementCategory = "Infrastructure",
                    AnnouncementStatus = AnnouncementStatus.Sent,
                },
                new Announcement
                {
                    AnnouncementTitle = "Water Supply Interruption",
                    AnnouncementDescription =
                        "Water supply will be temporarily interrupted for system maintenance",
                    AnnouncementDate = DateTime.Now.AddDays(-1),
                    AnnouncementLocation = "Downtown Area",
                    AnnouncementCategory = "Utilities",
                    AnnouncementStatus = AnnouncementStatus.Sent,
                },
                new Announcement
                {
                    AnnouncementTitle = "New Recycling Program",
                    AnnouncementDescription =
                        "Introducing a new recycling program for all residents",
                    AnnouncementDate = DateTime.Now,
                    AnnouncementLocation = "City Wide",
                    AnnouncementCategory = "Environment",
                    AnnouncementStatus = AnnouncementStatus.Sent,
                },
                new Announcement
                {
                    AnnouncementTitle = "Community Safety Meeting",
                    AnnouncementDescription =
                        "Join us for a community safety meeting to discuss neighborhood security",
                    AnnouncementDate = DateTime.Now.AddDays(1),
                    AnnouncementLocation = "Community Center",
                    AnnouncementCategory = "Safety",
                    AnnouncementStatus = AnnouncementStatus.Pending,
                },
                new Announcement
                {
                    AnnouncementTitle = "Tax Payment Deadline Reminder",
                    AnnouncementDescription =
                        "Reminder: Property tax payments are due by the end of the month",
                    AnnouncementDate = DateTime.Now.AddDays(3),
                    AnnouncementLocation = "City Wide",
                    AnnouncementCategory = "Finance",
                    AnnouncementStatus = AnnouncementStatus.Pending,
                },
                new Announcement
                {
                    AnnouncementTitle = "Library Extended Hours",
                    AnnouncementDescription =
                        "The municipal library will have extended hours during exam period",
                    AnnouncementDate = DateTime.Now.AddDays(5),
                    AnnouncementLocation = "Municipal Library",
                    AnnouncementCategory = "Education",
                    AnnouncementStatus = AnnouncementStatus.Pending,
                },
            };

            foreach (var announcement in sampleAnnouncements)
            {
                AddAnnouncement(announcement);
            }
        }

        public static void AddAnnouncement(Announcement announcement)
        {
            if (announcement == null)
                return;

            // Add to category hash table
            if (!_announcementsByCategory.ContainsKey(announcement.AnnouncementCategory))
            {
                _announcementsByCategory[announcement.AnnouncementCategory] =
                    new List<Announcement>();
            }
            _announcementsByCategory[announcement.AnnouncementCategory].Add(announcement);

            // Add to ID lookup hash table
            _announcementLookup[announcement.AnnouncementId] = announcement;

            // Add to date sorted dictionary
            var dateKey = announcement.AnnouncementDate.Date;
            if (!_announcementsByDate.ContainsKey(dateKey))
            {
                _announcementsByDate[dateKey] = new List<Announcement>();
            }
            _announcementsByDate[dateKey].Add(announcement);

            // Add to categories set
            _announcementCategories.Add(announcement.AnnouncementCategory);

            // Add to delivery queue
            _announcementQueue.Enqueue(announcement);
        }

        public static List<Announcement> GetAnnouncementsByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return GetAllAnnouncements();

            return _announcementsByCategory.TryGetValue(
                category,
                out List<Announcement> announcements
            )
                ? announcements.OrderByDescending(a => a.AnnouncementDate).ToList()
                : new List<Announcement>();
        }

        public static List<Announcement> GetAnnouncementsByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return GetAllAnnouncements();

            return _announcementLookup
                .Values.Where(a =>
                    a.AnnouncementLocation != null
                    && a.AnnouncementLocation.Contains(location) // ,StringComparison.OrdinalIgnoreCase
                )
                .OrderByDescending(a => a.AnnouncementDate)
                .ToList();
        }

        public static List<Announcement> GetRecentAnnouncements(int days = 7)
        {
            var cutoffDate = DateTime.Now.AddDays(-days);
            return _announcementLookup
                .Values.Where(a => a.AnnouncementDate >= cutoffDate)
                .OrderByDescending(a => a.AnnouncementDate)
                .ToList();
        }

        public static List<Announcement> GetPendingAnnouncements()
        {
            return _announcementLookup
                .Values.Where(a => a.AnnouncementStatus == AnnouncementStatus.Pending)
                .OrderBy(a => a.AnnouncementDate)
                .ToList();
        }

        public static Announcement GetAnnouncementById(Guid announcementId)
        {
            return _announcementLookup.TryGetValue(announcementId, out Announcement announcement)
                ? announcement
                : null;
        }

        public static List<Announcement> GetAllAnnouncements()
        {
            return _announcementLookup.Values.OrderByDescending(a => a.AnnouncementDate).ToList();
        }

        public static List<Announcement> SearchAnnouncements(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return GetAllAnnouncements();

            var query = searchQuery.ToLower();
            return _announcementLookup
                .Values.Where(a =>
                    a.AnnouncementTitle.ToLower().Contains(query)
                    || a.AnnouncementDescription.ToLower().Contains(query)
                    || (
                        a.AnnouncementLocation != null
                        && a.AnnouncementLocation.ToLower().Contains(query)
                    )
                    || a.AnnouncementCategory.ToLower().Contains(query)
                )
                .OrderByDescending(a => a.AnnouncementDate)
                .ToList();
        }

        public static List<string> GetAnnouncementCategories()
        {
            return _announcementCategories.ToList();
        }

        public static void MarkAnnouncementAsRead(Guid announcementId)
        {
            if (_announcementLookup.TryGetValue(announcementId, out Announcement announcement))
            {
                // Track reading activity for recommendations
                SearchService.TrackAnnouncementRead(announcement);
            }
        }

        public static List<Announcement> GetAnnouncementsForDelivery()
        {
            var announcements = new List<Announcement>();
            while (_announcementQueue.Count > 0)
            {
                announcements.Add(_announcementQueue.Dequeue());
            }
            return announcements;
        }

        public static Dictionary<string, int> GetAnnouncementStatistics()
        {
            var stats = new Dictionary<string, int>
            {
                ["Total Announcements"] = _announcementLookup.Count,
                ["Sent Announcements"] = _announcementLookup.Values.Count(a =>
                    a.AnnouncementStatus == AnnouncementStatus.Sent
                ),
                ["Pending Announcements"] = _announcementLookup.Values.Count(a =>
                    a.AnnouncementStatus == AnnouncementStatus.Pending
                ),
                ["Categories"] = _announcementCategories.Count,
                ["Recent (7 days)"] = GetRecentAnnouncements(7).Count,
            };

            // Add category breakdown
            foreach (var category in _announcementCategories)
            {
                stats[$"Category: {category}"] = _announcementsByCategory[category].Count;
            }

            return stats;
        }

        public static List<Announcement> GetAnnouncementsByDateRange(
            DateTime startDate,
            DateTime endDate
        )
        {
            return _announcementLookup
                .Values.Where(a => a.AnnouncementDate >= startDate && a.AnnouncementDate <= endDate)
                .OrderByDescending(a => a.AnnouncementDate)
                .ToList();
        }
    }
}
