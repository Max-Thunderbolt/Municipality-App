using System;
using System.Collections.Generic;
using System.Linq;
using Municipality_App.Models;

namespace Municipality_App.Services
{
    public static class SearchService
    {
        // Sorted Dictionary for tracking search patterns by timestamp
        private static readonly SortedDictionary<DateTime, UserSearch> _searchHistory =
            new SortedDictionary<DateTime, UserSearch>();

        // Hash Table for quick search lookup by category
        private static readonly Dictionary<string, List<UserSearch>> _searchesByCategory =
            new Dictionary<string, List<UserSearch>>();

        // Set for tracking popular search terms
        private static readonly HashSet<string> _popularSearchTerms = new HashSet<string>();

        // Dictionary for tracking search frequency
        private static readonly Dictionary<string, int> _searchFrequency =
            new Dictionary<string, int>();

        // List for tracking announcement reads
        private static readonly List<Announcement> _readAnnouncements = new List<Announcement>();

        public static void TrackSearch(UserSearch search)
        {
            if (search == null)
                return;

            // Add to search history
            _searchHistory[search.SearchTimestamp] = search;

            // Add to category hash table
            if (!_searchesByCategory.ContainsKey(search.SearchCategory))
            {
                _searchesByCategory[search.SearchCategory] = new List<UserSearch>();
            }
            _searchesByCategory[search.SearchCategory].Add(search);

            // Track search frequency
            var searchKey = search.SearchQuery.ToLower();
            if (!_searchFrequency.ContainsKey(searchKey))
            {
                _searchFrequency[searchKey] = 0;
            }
            _searchFrequency[searchKey]++;

            // Add to popular terms if frequency is high enough
            if (_searchFrequency[searchKey] >= 3)
            {
                _popularSearchTerms.Add(searchKey);
            }
        }

        public static void TrackAnnouncementRead(Announcement announcement)
        {
            if (announcement != null && !_readAnnouncements.Contains(announcement))
            {
                _readAnnouncements.Add(announcement);
            }
        }

        public static List<UserSearch> GetSearchHistory()
        {
            return _searchHistory.Values.OrderByDescending(s => s.SearchTimestamp).ToList();
        }

        public static List<UserSearch> GetSearchesByCategory(string category)
        {
            return _searchesByCategory.TryGetValue(category, out List<UserSearch> searches)
                ? searches.OrderByDescending(s => s.SearchTimestamp).ToList()
                : new List<UserSearch>();
        }

        public static List<string> GetPopularSearchTerms()
        {
            return _popularSearchTerms.ToList();
        }

        public static Dictionary<string, int> GetSearchFrequency()
        {
            return new Dictionary<string, int>(_searchFrequency);
        }

        public static List<string> GetSearchSuggestions(string partialQuery)
        {
            if (string.IsNullOrWhiteSpace(partialQuery))
                return GetPopularSearchTerms();

            var query = partialQuery.ToLower();
            var suggestions = new List<string>();

            // Find searches that start with the partial query
            foreach (var search in _searchHistory.Values)
            {
                if (search.SearchQuery.ToLower().StartsWith(query))
                {
                    suggestions.Add(search.SearchQuery);
                }
            }

            // Add popular terms that contain the partial query
            foreach (var term in _popularSearchTerms)
            {
                if (term.Contains(query) && !suggestions.Contains(term))
                {
                    suggestions.Add(term);
                }
            }

            return suggestions.Distinct().Take(10).ToList();
        }

        public static List<Announcement> GetRecommendedAnnouncements()
        {
            var recommendations = new List<Announcement>();

            // Get user's read announcement categories
            var readCategories = _readAnnouncements
                .Select(a => a.AnnouncementCategory)
                .Distinct()
                .ToList();

            // Get user's search categories
            var searchCategories = _searchesByCategory.Keys.ToList();

            // Combine categories for recommendations
            var allCategories = readCategories.Union(searchCategories).Distinct().ToList();

            foreach (var category in allCategories)
            {
                var categoryAnnouncements = AnnouncementService.GetAnnouncementsByCategory(
                    category
                );
                recommendations.AddRange(categoryAnnouncements.Take(2)); // Limit to 2 per category
            }

            return recommendations
                .Distinct()
                .OrderByDescending(a => a.AnnouncementDate)
                .Take(5)
                .ToList();
        }

        public static List<Event> GetRecommendedEvents()
        {
            var recommendations = new List<Event>();

            // Get user's read announcement categories
            var readCategories = _readAnnouncements
                .Select(a => a.AnnouncementCategory)
                .Distinct()
                .ToList();

            // Get user's search categories
            var searchCategories = _searchesByCategory.Keys.ToList();

            // Combine categories for recommendations
            var allCategories = readCategories.Union(searchCategories).Distinct().ToList();

            foreach (var category in allCategories)
            {
                var categoryEvents = EventService.GetEventsByCategory(category);
                recommendations.AddRange(categoryEvents.Take(2)); // Limit to 2 per category
            }

            return recommendations.Distinct().OrderBy(e => e.EventDate).Take(5).ToList();
        }

        public static Dictionary<string, object> GetSearchAnalytics()
        {
            var analytics = new Dictionary<string, object>
            {
                ["Total Searches"] = _searchHistory.Count,
                ["Unique Search Terms"] = _searchFrequency.Count,
                ["Popular Terms"] = _popularSearchTerms.Count,
                ["Categories Searched"] = _searchesByCategory.Count,
                ["Announcements Read"] = _readAnnouncements.Count,
                ["Most Searched Category"] = GetMostSearchedCategory(),
                ["Most Popular Term"] = GetMostPopularTerm(),
                ["Search Success Rate"] = GetSearchSuccessRate(),
            };

            return analytics;
        }

        private static string GetMostSearchedCategory()
        {
            if (_searchesByCategory.Count == 0)
                return "None";

            return _searchesByCategory.OrderByDescending(kvp => kvp.Value.Count).First().Key;
        }

        private static string GetMostPopularTerm()
        {
            if (_searchFrequency.Count == 0)
                return "None";

            return _searchFrequency.OrderByDescending(kvp => kvp.Value).First().Key;
        }

        private static double GetSearchSuccessRate()
        {
            if (_searchHistory.Count == 0)
                return 0.0;

            var successfulSearches = _searchHistory.Values.Count(s => s.WasSuccessful);
            return (double)successfulSearches / _searchHistory.Count * 100;
        }

        public static List<UserSearch> GetRecentSearches(int count = 10)
        {
            return _searchHistory
                .Values.OrderByDescending(s => s.SearchTimestamp)
                .Take(count)
                .ToList();
        }

        public static void ClearSearchHistory()
        {
            _searchHistory.Clear();
            _searchesByCategory.Clear();
            _popularSearchTerms.Clear();
            _searchFrequency.Clear();
            _readAnnouncements.Clear();
        }
    }
}
