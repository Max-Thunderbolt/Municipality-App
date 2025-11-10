using System;
using Municipality_App.Models;
using Municipality_App.Structures;

namespace Municipality_App.Services
{
    public static class SearchService
    {
        // Sorted Dictionary for tracking search patterns by timestamp
        private static readonly CustomSortedDictionary<DateTime, UserSearch> _searchHistory =
            new CustomSortedDictionary<DateTime, UserSearch>();

        // Hash Table for quick search lookup by category
        private static readonly CustomDictionary<
            string,
            CustomList<UserSearch>
        > _searchesByCategory = new CustomDictionary<string, CustomList<UserSearch>>();

        // Set for tracking popular search terms
        private static readonly CustomHashSet<string> _popularSearchTerms =
            new CustomHashSet<string>();

        // Dictionary for tracking search frequency
        private static readonly CustomDictionary<string, int> _searchFrequency =
            new CustomDictionary<string, int>();

        // List for tracking announcement reads
        private static readonly CustomList<Announcement> _readAnnouncements =
            new CustomList<Announcement>();

        public static void TrackSearch(UserSearch search)
        {
            if (search == null)
                return;

            // Add to search history
            _searchHistory[search.SearchTimestamp] = search;

            // Add to category hash table
            if (!_searchesByCategory.ContainsKey(search.SearchCategory))
            {
                _searchesByCategory.Add(search.SearchCategory, new CustomList<UserSearch>());
            }
            _searchesByCategory[search.SearchCategory].Add(search);

            // Track search frequency
            var searchKey = search.SearchQuery.ToLower();
            if (!_searchFrequency.ContainsKey(searchKey))
            {
                _searchFrequency.Add(searchKey, 0);
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
            if (announcement != null)
            {
                bool found = false;
                foreach (var existing in _readAnnouncements)
                {
                    if (existing.AnnouncementId == announcement.AnnouncementId)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    _readAnnouncements.Add(announcement);
                }
            }
        }

        public static CustomList<UserSearch> GetSearchHistory()
        {
            var result = new CustomList<UserSearch>();
            foreach (var search in _searchHistory.Values)
            {
                result.Add(search);
            }
            // Sort by timestamp descending
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].SearchTimestamp < result[j].SearchTimestamp)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static CustomList<UserSearch> GetSearchesByCategory(string category)
        {
            if (_searchesByCategory.TryGetValue(category, out CustomList<UserSearch> searches))
            {
                var result = new CustomList<UserSearch>();
                foreach (var search in searches)
                {
                    result.Add(search);
                }
                // Sort by timestamp descending
                for (int i = 0; i < result.Count - 1; i++)
                {
                    for (int j = i + 1; j < result.Count; j++)
                    {
                        if (result[i].SearchTimestamp < result[j].SearchTimestamp)
                        {
                            var temp = result[i];
                            result[i] = result[j];
                            result[j] = temp;
                        }
                    }
                }
                return result;
            }
            return new CustomList<UserSearch>();
        }

        public static CustomList<string> GetPopularSearchTerms()
        {
            return _popularSearchTerms.ToList();
        }

        public static CustomDictionary<string, int> GetSearchFrequency()
        {
            var result = new CustomDictionary<string, int>();
            foreach (var kvp in _searchFrequency)
            {
                result.Add(kvp.Key, kvp.Value);
            }
            return result;
        }

        public static CustomList<string> GetSearchSuggestions(string partialQuery)
        {
            if (string.IsNullOrWhiteSpace(partialQuery))
                return GetPopularSearchTerms();

            var query = partialQuery.ToLower();
            var suggestions = new CustomHashSet<string>();

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
                if (term.Contains(query))
                {
                    suggestions.Add(term);
                }
            }

            var result = suggestions.ToList();
            // Limit to 10
            if (result.Count > 10)
            {
                var limited = new CustomList<string>();
                for (int i = 0; i < 10; i++)
                {
                    limited.Add(result[i]);
                }
                return limited;
            }
            return result;
        }

        public static CustomList<Announcement> GetRecommendedAnnouncements()
        {
            var recommendations = new CustomList<Announcement>();

            // Get user's read announcement categories
            var readCategories = new CustomHashSet<string>();
            foreach (var announcement in _readAnnouncements)
            {
                readCategories.Add(announcement.AnnouncementCategory);
            }

            // Get user's search categories
            var searchCategories = _searchesByCategory.Keys;

            // Combine categories for recommendations
            var allCategories = new CustomHashSet<string>();
            foreach (var category in readCategories)
            {
                allCategories.Add(category);
            }
            foreach (var category in searchCategories)
            {
                allCategories.Add(category);
            }

            var seenAnnouncements = new CustomHashSet<Guid>();
            foreach (var category in allCategories)
            {
                var categoryAnnouncements = AnnouncementService.GetAnnouncementsByCategory(
                    category
                );
                int count = 0;
                foreach (var announcement in categoryAnnouncements)
                {
                    if (count >= 2)
                        break;
                    if (!seenAnnouncements.Contains(announcement.AnnouncementId))
                    {
                        recommendations.Add(announcement);
                        seenAnnouncements.Add(announcement.AnnouncementId);
                        count++;
                    }
                }
            }

            // Sort by date descending and take top 5
            for (int i = 0; i < recommendations.Count - 1; i++)
            {
                for (int j = i + 1; j < recommendations.Count; j++)
                {
                    if (recommendations[i].AnnouncementDate < recommendations[j].AnnouncementDate)
                    {
                        var temp = recommendations[i];
                        recommendations[i] = recommendations[j];
                        recommendations[j] = temp;
                    }
                }
            }

            if (recommendations.Count > 5)
            {
                var limited = new CustomList<Announcement>();
                for (int i = 0; i < 5; i++)
                {
                    limited.Add(recommendations[i]);
                }
                return limited;
            }
            return recommendations;
        }

        public static CustomList<Event> GetRecommendedEvents()
        {
            var recommendations = new CustomList<Event>();

            // Get user's read announcement categories
            var readCategories = new CustomHashSet<string>();
            foreach (var announcement in _readAnnouncements)
            {
                readCategories.Add(announcement.AnnouncementCategory);
            }

            // Get user's search categories
            var searchCategories = _searchesByCategory.Keys;

            // Combine categories for recommendations
            var allCategories = new CustomHashSet<string>();
            foreach (var category in readCategories)
            {
                allCategories.Add(category);
            }
            foreach (var category in searchCategories)
            {
                allCategories.Add(category);
            }

            var seenEvents = new CustomHashSet<Guid>();
            foreach (var category in allCategories)
            {
                var categoryEvents = EventService.GetEventsByCategory(category);
                int count = 0;
                foreach (var evt in categoryEvents)
                {
                    if (count >= 2)
                        break;
                    if (!seenEvents.Contains(evt.EventId))
                    {
                        recommendations.Add(evt);
                        seenEvents.Add(evt.EventId);
                        count++;
                    }
                }
            }

            // Sort by date ascending and take top 5
            for (int i = 0; i < recommendations.Count - 1; i++)
            {
                for (int j = i + 1; j < recommendations.Count; j++)
                {
                    if (recommendations[i].EventDate > recommendations[j].EventDate)
                    {
                        var temp = recommendations[i];
                        recommendations[i] = recommendations[j];
                        recommendations[j] = temp;
                    }
                }
            }

            if (recommendations.Count > 5)
            {
                var limited = new CustomList<Event>();
                for (int i = 0; i < 5; i++)
                {
                    limited.Add(recommendations[i]);
                }
                return limited;
            }
            return recommendations;
        }

        public static CustomDictionary<string, object> GetSearchAnalytics()
        {
            var analytics = new CustomDictionary<string, object>();
            analytics.Add("Total Searches", _searchHistory.Count);
            analytics.Add("Unique Search Terms", _searchFrequency.Count);
            analytics.Add("Popular Terms", _popularSearchTerms.Count);
            analytics.Add("Categories Searched", _searchesByCategory.Count);
            analytics.Add("Announcements Read", _readAnnouncements.Count);
            analytics.Add("Most Searched Category", GetMostSearchedCategory());
            analytics.Add("Most Popular Term", GetMostPopularTerm());
            analytics.Add("Search Success Rate", GetSearchSuccessRate());

            return analytics;
        }

        private static string GetMostSearchedCategory()
        {
            if (_searchesByCategory.Count == 0)
                return "None";

            string maxCategory = "";
            int maxCount = 0;
            foreach (var kvp in _searchesByCategory)
            {
                if (kvp.Value.Count > maxCount)
                {
                    maxCount = kvp.Value.Count;
                    maxCategory = kvp.Key;
                }
            }
            return maxCategory;
        }

        private static string GetMostPopularTerm()
        {
            if (_searchFrequency.Count == 0)
                return "None";

            string maxTerm = "";
            int maxFrequency = 0;
            foreach (var kvp in _searchFrequency)
            {
                if (kvp.Value > maxFrequency)
                {
                    maxFrequency = kvp.Value;
                    maxTerm = kvp.Key;
                }
            }
            return maxTerm;
        }

        private static double GetSearchSuccessRate()
        {
            if (_searchHistory.Count == 0)
                return 0.0;

            int successfulSearches = 0;
            foreach (var search in _searchHistory.Values)
            {
                if (search.WasSuccessful)
                {
                    successfulSearches++;
                }
            }
            return (double)successfulSearches / _searchHistory.Count * 100;
        }

        public static CustomList<UserSearch> GetRecentSearches(int count = 10)
        {
            var allSearches = new CustomList<UserSearch>();
            foreach (var search in _searchHistory.Values)
            {
                allSearches.Add(search);
            }
            // Sort by timestamp descending
            for (int i = 0; i < allSearches.Count - 1; i++)
            {
                for (int j = i + 1; j < allSearches.Count; j++)
                {
                    if (allSearches[i].SearchTimestamp < allSearches[j].SearchTimestamp)
                    {
                        var temp = allSearches[i];
                        allSearches[i] = allSearches[j];
                        allSearches[j] = temp;
                    }
                }
            }
            // Take first count items
            var result = new CustomList<UserSearch>();
            int takeCount = Math.Min(count, allSearches.Count);
            for (int i = 0; i < takeCount; i++)
            {
                result.Add(allSearches[i]);
            }
            return result;
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
