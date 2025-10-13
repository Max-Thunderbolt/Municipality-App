using System;
using System.Collections.Generic;
using System.Linq;
using Municipality_App.Models;

namespace Municipality_App.Services
{
    public static class RecommendationService
    {
        // Sorted Dictionary for recommendation scoring
        private static readonly SortedDictionary<double, List<object>> _recommendationScores =
            new SortedDictionary<double, List<object>>();

        // Set for tracking user preferences
        private static readonly HashSet<string> _userPreferences = new HashSet<string>();

        // Dictionary for recommendation history
        private static readonly Dictionary<Guid, DateTime> _recommendationHistory =
            new Dictionary<Guid, DateTime>();

        public static List<object> GetPersonalizedRecommendations()
        {
            var recommendations = new List<object>();

            // Get user profile for personalization
            var userProfile = GamificationService.GetProfile();

            // Get user's search patterns
            var searchHistory = SearchService.GetSearchHistory();
            var recentSearches = searchHistory.Take(10).ToList();

            // Get user's interests from events
            var userInterests = EventService.GetUserInterests();

            // Get read announcements
            var readAnnouncements = SearchService.GetRecentSearches(5);

            // Calculate recommendation scores
            var eventRecommendations = GetEventRecommendations(
                userProfile,
                userInterests,
                recentSearches
            );
            var announcementRecommendations = GetAnnouncementRecommendations(
                userProfile,
                readAnnouncements,
                recentSearches
            );

            // Combine and score recommendations
            recommendations.AddRange(eventRecommendations);
            recommendations.AddRange(announcementRecommendations);

            // Sort by relevance score
            return recommendations
                .OrderByDescending(r => GetRecommendationScore(r, userProfile))
                .ToList();
        }

        private static List<Event> GetEventRecommendations(
            UserProfile userProfile,
            List<string> userInterests,
            List<UserSearch> recentSearches
        )
        {
            var recommendations = new List<Event>();
            var upcomingEvents = EventService.GetUpcomingEvents();

            foreach (var evt in upcomingEvents)
            {
                var score = CalculateEventScore(evt, userProfile, userInterests, recentSearches);
                if (score > 0.3) // Minimum relevance threshold
                {
                    recommendations.Add(evt);
                }
            }

            return recommendations
                .OrderByDescending(e =>
                    CalculateEventScore(e, userProfile, userInterests, recentSearches)
                )
                .Take(5)
                .ToList();
        }

        private static List<Announcement> GetAnnouncementRecommendations(
            UserProfile userProfile,
            List<UserSearch> recentSearches,
            List<UserSearch> allSearches
        )
        {
            var recommendations = new List<Announcement>();
            var recentAnnouncements = AnnouncementService.GetRecentAnnouncements(30);

            foreach (var announcement in recentAnnouncements)
            {
                var score = CalculateAnnouncementScore(announcement, userProfile, recentSearches);
                if (score > 0.2) // Minimum relevance threshold
                {
                    recommendations.Add(announcement);
                }
            }

            return recommendations
                .OrderByDescending(a => CalculateAnnouncementScore(a, userProfile, recentSearches))
                .Take(5)
                .ToList();
        }

        private static double CalculateEventScore(
            Event evt,
            UserProfile userProfile,
            List<string> userInterests,
            List<UserSearch> recentSearches
        )
        {
            double score = 0.0;

            // Base score for upcoming events
            if (evt.EventStatus == EventStatus.Upcoming)
            {
                score += 0.5;
            }

            // Interest matching
            if (userInterests.Contains(evt.EventCategory))
            {
                score += 0.3;
            }

            // Search pattern matching
            foreach (var search in recentSearches)
            {
                if (
                    evt.EventName.ToLower().Contains(search.SearchQuery.ToLower())
                    || evt.EventDescription.ToLower().Contains(search.SearchQuery.ToLower())
                    || evt.EventCategory.ToLower().Contains(search.SearchQuery.ToLower())
                )
                {
                    score += 0.2;
                }
            }

            // User activity level
            if (userProfile.Points > 100)
            {
                score += 0.1; // Bonus for active users
            }

            // Recency bonus
            var daysUntilEvent = (evt.EventDate - DateTime.Now).TotalDays;
            if (daysUntilEvent <= 7)
            {
                score += 0.2;
            }
            else if (daysUntilEvent <= 30)
            {
                score += 0.1;
            }

            return Math.Min(score, 1.0); // Cap at 1.0
        }

        private static double CalculateAnnouncementScore(
            Announcement announcement,
            UserProfile userProfile,
            List<UserSearch> recentSearches
        )
        {
            double score = 0.0;

            // Base score for recent announcements
            var daysSinceAnnouncement = (DateTime.Now - announcement.AnnouncementDate).TotalDays;
            if (daysSinceAnnouncement <= 7)
            {
                score += 0.4;
            }
            else if (daysSinceAnnouncement <= 30)
            {
                score += 0.2;
            }

            // Search pattern matching
            foreach (var search in recentSearches)
            {
                if (
                    announcement.AnnouncementTitle.ToLower().Contains(search.SearchQuery.ToLower())
                    || announcement
                        .AnnouncementDescription.ToLower()
                        .Contains(search.SearchQuery.ToLower())
                    || announcement
                        .AnnouncementCategory.ToLower()
                        .Contains(search.SearchQuery.ToLower())
                )
                {
                    score += 0.3;
                }
            }

            // User activity level
            if (userProfile.Points > 50)
            {
                score += 0.1; // Bonus for active users
            }

            // Category relevance based on user's submitted issues
            var userIssueCategories = userProfile
                .SubmittedIssues.Select(i => i.Category)
                .Distinct()
                .ToList();
            if (userIssueCategories.Contains(announcement.AnnouncementCategory))
            {
                score += 0.2;
            }

            return Math.Min(score, 1.0); // Cap at 1.0
        }

        private static double GetRecommendationScore(object recommendation, UserProfile userProfile)
        {
            if (recommendation is Event evt)
            {
                return CalculateEventScore(
                    evt,
                    userProfile,
                    EventService.GetUserInterests(),
                    SearchService.GetRecentSearches(10)
                );
            }
            else if (recommendation is Announcement announcement)
            {
                return CalculateAnnouncementScore(
                    announcement,
                    userProfile,
                    SearchService.GetRecentSearches(10)
                );
            }

            return 0.0;
        }

        public static List<string> GetSearchSuggestions(string partialQuery)
        {
            return SearchService.GetSearchSuggestions(partialQuery);
        }

        public static List<Event> GetRecommendedEventsForUser()
        {
            var userProfile = GamificationService.GetProfile();
            var userInterests = EventService.GetUserInterests();
            var recentSearches = SearchService.GetRecentSearches(5);

            return GetEventRecommendations(userProfile, userInterests, recentSearches);
        }

        public static List<Announcement> GetRecommendedAnnouncementsForUser()
        {
            var userProfile = GamificationService.GetProfile();
            var recentSearches = SearchService.GetRecentSearches(5);

            return GetAnnouncementRecommendations(
                userProfile,
                recentSearches,
                SearchService.GetSearchHistory()
            );
        }

        public static Dictionary<string, object> GetRecommendationAnalytics()
        {
            var analytics = new Dictionary<string, object>
            {
                ["Total Recommendations Generated"] = _recommendationHistory.Count,
                ["User Preferences Tracked"] = _userPreferences.Count,
                ["Recommendation Score Ranges"] = GetRecommendationScoreRanges(),
                ["Most Recommended Categories"] = GetMostRecommendedCategories(),
                ["Recommendation Success Rate"] = GetRecommendationSuccessRate(),
            };

            return analytics;
        }

        private static Dictionary<string, int> GetRecommendationScoreRanges()
        {
            var ranges = new Dictionary<string, int>
            {
                ["High (0.8-1.0)"] = 0,
                ["Medium (0.5-0.8)"] = 0,
                ["Low (0.0-0.5)"] = 0,
            };

            foreach (var score in _recommendationScores.Keys)
            {
                if (score >= 0.8)
                    ranges["High (0.8-1.0)"]++;
                else if (score >= 0.5)
                    ranges["Medium (0.5-0.8)"]++;
                else
                    ranges["Low (0.0-0.5)"]++;
            }

            return ranges;
        }

        private static List<string> GetMostRecommendedCategories()
        {
            var categoryCounts = new Dictionary<string, int>();

            foreach (var recommendations in _recommendationScores.Values)
            {
                foreach (var rec in recommendations)
                {
                    string category = "";
                    if (rec is Event evt)
                        category = evt.EventCategory;
                    else if (rec is Announcement announcement)
                        category = announcement.AnnouncementCategory;

                    if (!string.IsNullOrEmpty(category))
                    {
                        if (!categoryCounts.ContainsKey(category))
                            categoryCounts[category] = 0;
                        categoryCounts[category]++;
                    }
                }
            }

            return categoryCounts
                .OrderByDescending(kvp => kvp.Value)
                .Select(kvp => kvp.Key)
                .Take(5)
                .ToList();
        }

        private static double GetRecommendationSuccessRate()
        {
            // This would typically track user interactions with recommendations
            // For now, return a placeholder value
            return 75.0; // 75% success rate
        }

        public static void TrackRecommendationInteraction(Guid recommendationId)
        {
            _recommendationHistory[recommendationId] = DateTime.Now;
        }

        public static void AddUserPreference(string preference)
        {
            _userPreferences.Add(preference);
        }

        public static List<string> GetUserPreferences()
        {
            return _userPreferences.ToList();
        }
    }
}
