using System;
using Municipality_App.Models;
using Municipality_App.Structures;

namespace Municipality_App.Services
{
    public static class AnnouncementService
    {
        // Hash Table for quick announcement lookup by category
        private static readonly CustomDictionary<
            string,
            CustomList<Announcement>
        > _announcementsByCategory = new CustomDictionary<string, CustomList<Announcement>>();

        // Hash Table for quick announcement lookup by ID
        private static readonly CustomDictionary<Guid, Announcement> _announcementLookup =
            new CustomDictionary<Guid, Announcement>();

        // Sorted Dictionary for announcements sorted by date
        private static readonly CustomSortedDictionary<
            DateTime,
            CustomList<Announcement>
        > _announcementsByDate = new CustomSortedDictionary<DateTime, CustomList<Announcement>>();

        // Set for tracking announcement categories
        private static readonly CustomHashSet<string> _announcementCategories =
            new CustomHashSet<string>();

        // Queue for announcement delivery
        private static readonly CustomQueue<Announcement> _announcementQueue =
            new CustomQueue<Announcement>();

        static AnnouncementService()
        {
            InitializeSampleAnnouncements();
        }

        private static void InitializeSampleAnnouncements()
        {
            var sampleAnnouncements = new CustomList<Announcement>
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
                _announcementsByCategory.Add(
                    announcement.AnnouncementCategory,
                    new CustomList<Announcement>()
                );
            }
            _announcementsByCategory[announcement.AnnouncementCategory].Add(announcement);

            // Add to ID lookup hash table
            _announcementLookup[announcement.AnnouncementId] = announcement;

            // Add to date sorted dictionary
            var dateKey = announcement.AnnouncementDate.Date;
            if (!_announcementsByDate.ContainsKey(dateKey))
            {
                _announcementsByDate.Add(dateKey, new CustomList<Announcement>());
            }
            _announcementsByDate[dateKey].Add(announcement);

            // Add to categories set
            _announcementCategories.Add(announcement.AnnouncementCategory);

            // Add to delivery queue
            _announcementQueue.Enqueue(announcement);
        }

        public static CustomList<Announcement> GetAnnouncementsByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return GetAllAnnouncements();

            if (
                _announcementsByCategory.TryGetValue(
                    category,
                    out CustomList<Announcement> announcements
                )
            )
            {
                var result = new CustomList<Announcement>();
                foreach (var announcement in announcements)
                {
                    result.Add(announcement);
                }
                // Sort by date descending
                for (int i = 0; i < result.Count - 1; i++)
                {
                    for (int j = i + 1; j < result.Count; j++)
                    {
                        if (result[i].AnnouncementDate < result[j].AnnouncementDate)
                        {
                            var temp = result[i];
                            result[i] = result[j];
                            result[j] = temp;
                        }
                    }
                }
                return result;
            }
            return new CustomList<Announcement>();
        }

        public static CustomList<Announcement> GetAnnouncementsByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return GetAllAnnouncements();

            var result = new CustomList<Announcement>();
            foreach (var announcement in _announcementLookup.Values)
            {
                if (
                    announcement.AnnouncementLocation != null
                    && announcement.AnnouncementLocation.Contains(location)
                )
                {
                    result.Add(announcement);
                }
            }
            // Sort by date descending
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].AnnouncementDate < result[j].AnnouncementDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static CustomList<Announcement> GetRecentAnnouncements(int days = 7)
        {
            var cutoffDate = DateTime.Now.AddDays(-days);
            var result = new CustomList<Announcement>();
            foreach (var announcement in _announcementLookup.Values)
            {
                if (announcement.AnnouncementDate >= cutoffDate)
                {
                    result.Add(announcement);
                }
            }
            // Sort by date descending
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].AnnouncementDate < result[j].AnnouncementDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static CustomList<Announcement> GetPendingAnnouncements()
        {
            var result = new CustomList<Announcement>();
            foreach (var announcement in _announcementLookup.Values)
            {
                if (announcement.AnnouncementStatus == AnnouncementStatus.Pending)
                {
                    result.Add(announcement);
                }
            }
            // Sort by date ascending
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].AnnouncementDate > result[j].AnnouncementDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static Announcement GetAnnouncementById(Guid announcementId)
        {
            return _announcementLookup.TryGetValue(announcementId, out Announcement announcement)
                ? announcement
                : null;
        }

        public static CustomList<Announcement> GetAllAnnouncements()
        {
            var result = new CustomList<Announcement>();
            foreach (var announcement in _announcementLookup.Values)
            {
                result.Add(announcement);
            }
            // Sort by date descending
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].AnnouncementDate < result[j].AnnouncementDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static CustomList<Announcement> SearchAnnouncements(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return GetAllAnnouncements();

            var query = searchQuery.ToLower();
            var result = new CustomList<Announcement>();
            foreach (var announcement in _announcementLookup.Values)
            {
                if (
                    (
                        announcement.AnnouncementTitle != null
                        && announcement.AnnouncementTitle.ToLower().Contains(query)
                    )
                    || (
                        announcement.AnnouncementDescription != null
                        && announcement.AnnouncementDescription.ToLower().Contains(query)
                    )
                    || (
                        announcement.AnnouncementLocation != null
                        && announcement.AnnouncementLocation.ToLower().Contains(query)
                    )
                    || (
                        announcement.AnnouncementCategory != null
                        && announcement.AnnouncementCategory.ToLower().Contains(query)
                    )
                )
                {
                    result.Add(announcement);
                }
            }
            // Sort by date descending
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].AnnouncementDate < result[j].AnnouncementDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static CustomList<string> GetAnnouncementCategories()
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

        public static CustomList<Announcement> GetAnnouncementsForDelivery()
        {
            var announcements = new CustomList<Announcement>();
            while (_announcementQueue.Count > 0)
            {
                announcements.Add(_announcementQueue.Dequeue());
            }
            return announcements;
        }

        public static CustomDictionary<string, int> GetAnnouncementStatistics()
        {
            var stats = new CustomDictionary<string, int>();
            stats.Add("Total Announcements", _announcementLookup.Count);

            int sentCount = 0;
            int pendingCount = 0;
            foreach (var announcement in _announcementLookup.Values)
            {
                if (announcement.AnnouncementStatus == AnnouncementStatus.Sent)
                    sentCount++;
                else if (announcement.AnnouncementStatus == AnnouncementStatus.Pending)
                    pendingCount++;
            }

            stats.Add("Sent Announcements", sentCount);
            stats.Add("Pending Announcements", pendingCount);
            stats.Add("Categories", _announcementCategories.Count);
            stats.Add("Recent (7 days)", GetRecentAnnouncements(7).Count);

            // Add category breakdown
            foreach (var category in _announcementCategories)
            {
                stats.Add($"Category: {category}", _announcementsByCategory[category].Count);
            }

            return stats;
        }

        public static CustomList<Announcement> GetAnnouncementsByDateRange(
            DateTime startDate,
            DateTime endDate
        )
        {
            var result = new CustomList<Announcement>();
            foreach (var announcement in _announcementLookup.Values)
            {
                if (
                    announcement.AnnouncementDate >= startDate
                    && announcement.AnnouncementDate <= endDate
                )
                {
                    result.Add(announcement);
                }
            }
            // Sort by date descending
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].AnnouncementDate < result[j].AnnouncementDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }
    }
}
