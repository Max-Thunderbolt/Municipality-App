using System;
using Municipality_App.Models;
using Municipality_App.Structures;

namespace Municipality_App.Services
{
    public static class EventService
    {
        // Priority Queue for event management - events sorted by date and priority
        private static readonly CustomSortedDictionary<
            DateTime,
            CustomList<Event>
        > _eventPriorityQueue = new CustomSortedDictionary<DateTime, CustomList<Event>>();

        // Hash Table for quick event lookup by ID
        private static readonly CustomDictionary<Guid, Event> _eventLookup =
            new CustomDictionary<Guid, Event>();

        // Stack for event registration history (LIFO)
        private static readonly CustomStack<EventRegistration> _registrationHistory =
            new CustomStack<EventRegistration>();

        // HashSet for tracking user interests
        private static readonly CustomHashSet<string> _userInterests = new CustomHashSet<string>();

        // Queue for event notifications
        private static readonly CustomQueue<string> _eventNotifications = new CustomQueue<string>();

        static EventService()
        {
            InitializeSampleEvents();
        }

        private static void InitializeSampleEvents()
        {
            var sampleEvents = new CustomList<Event>
            {
                new Event
                {
                    EventName = "Community Clean-up Day",
                    EventDescription = "Join us for a community-wide clean-up initiative",
                    EventDate = DateTime.Now.AddDays(7),
                    EventLocation = "Central Park",
                    EventCategory = "Community Service",
                    EventStatus = EventStatus.Upcoming,
                },
                new Event
                {
                    EventName = "Municipal Budget Meeting",
                    EventDescription = "Public meeting to discuss municipal budget allocation",
                    EventDate = DateTime.Now.AddDays(14),
                    EventLocation = "Town Hall",
                    EventCategory = "Government",
                    EventStatus = EventStatus.Upcoming,
                },
                new Event
                {
                    EventName = "Environmental Awareness Workshop",
                    EventDescription = "Learn about sustainable living practices",
                    EventDate = DateTime.Now.AddDays(21),
                    EventLocation = "Community Center",
                    EventCategory = "Education",
                    EventStatus = EventStatus.Upcoming,
                },
                new Event
                {
                    EventName = "Youth Sports Tournament",
                    EventDescription = "Annual youth sports competition",
                    EventDate = DateTime.Now.AddDays(28),
                    EventLocation = "Sports Complex",
                    EventCategory = "Sports",
                    EventStatus = EventStatus.Upcoming,
                },
                new Event
                {
                    EventName = "Senior Citizens Social",
                    EventDescription = "Monthly social gathering for senior citizens",
                    EventDate = DateTime.Now.AddDays(35),
                    EventLocation = "Senior Center",
                    EventCategory = "Social",
                    EventStatus = EventStatus.Upcoming,
                },
            };

            foreach (var evt in sampleEvents)
            {
                AddEvent(evt);
            }
        }

        public static void AddEvent(Event evt)
        {
            if (evt == null)
                return;

            // Add to priority queue (sorted by date)
            if (!_eventPriorityQueue.ContainsKey(evt.EventDate.Date))
            {
                _eventPriorityQueue.Add(evt.EventDate.Date, new CustomList<Event>());
            }
            _eventPriorityQueue[evt.EventDate.Date].Add(evt);

            // Add to hash table for quick lookup
            _eventLookup[evt.EventId] = evt;

            // Add notification to queue
            _eventNotifications.Enqueue($"New event added: {evt.EventName}");
        }

        public static CustomList<Event> GetUpcomingEvents()
        {
            var upcomingEvents = new CustomList<Event>();
            var currentDate = DateTime.Now.Date;

            foreach (var kvp in _eventPriorityQueue)
            {
                if (kvp.Key >= currentDate)
                {
                    foreach (var evt in kvp.Value)
                    {
                        if (evt.EventStatus == EventStatus.Upcoming)
                        {
                            upcomingEvents.Add(evt);
                        }
                    }
                }
            }

            // Sort by event date
            for (int i = 0; i < upcomingEvents.Count - 1; i++)
            {
                for (int j = i + 1; j < upcomingEvents.Count; j++)
                {
                    if (upcomingEvents[i].EventDate > upcomingEvents[j].EventDate)
                    {
                        var temp = upcomingEvents[i];
                        upcomingEvents[i] = upcomingEvents[j];
                        upcomingEvents[j] = temp;
                    }
                }
            }
            return upcomingEvents;
        }

        public static CustomList<Event> GetEventsByCategory(string category)
        {
            var result = new CustomList<Event>();
            foreach (var evt in _eventLookup.Values)
            {
                if (evt.EventCategory.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(evt);
                }
            }
            // Sort by event date
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].EventDate > result[j].EventDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static CustomList<Event> GetEventsByLocation(string location)
        {
            var result = new CustomList<Event>();
            foreach (var evt in _eventLookup.Values)
            {
                if (evt.EventLocation != null && evt.EventLocation.Contains(location))
                {
                    result.Add(evt);
                }
            }
            // Sort by event date
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].EventDate > result[j].EventDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static Event GetEventById(Guid eventId)
        {
            return _eventLookup.TryGetValue(eventId, out Event evt) ? evt : null;
        }

        public static bool RegisterForEvent(
            Guid eventId,
            string userName,
            string userEmail,
            CustomList<string> specialRequirements = null
        )
        {
            var evt = GetEventById(eventId);
            if (evt == null || evt.EventStatus != EventStatus.Upcoming)
                return false;

            var registration = new EventRegistration
            {
                EventId = eventId,
                UserName = userName,
                UserEmail = userEmail,
                SpecialRequirements = specialRequirements ?? new CustomList<string>(),
                IsConfirmed = true,
            };

            // Add to registration history stack
            _registrationHistory.Push(registration);

            // Add to user interests set
            _userInterests.Add(evt.EventCategory);

            // Add notification
            _eventNotifications.Enqueue($"Registration confirmed for: {evt.EventName}");

            return true;
        }

        public static CustomList<EventRegistration> GetRegistrationHistory()
        {
            return _registrationHistory.ToList();
        }

        public static CustomList<string> GetUserInterests()
        {
            return _userInterests.ToList();
        }

        public static CustomList<string> GetEventNotifications()
        {
            var notifications = new CustomList<string>();
            while (_eventNotifications.Count > 0)
            {
                notifications.Add(_eventNotifications.Dequeue());
            }
            return notifications;
        }

        public static CustomList<Event> SearchEvents(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return GetUpcomingEvents();

            var query = searchQuery.ToLower();
            var result = new CustomList<Event>();
            foreach (var evt in _eventLookup.Values)
            {
                if (
                    (evt.EventName != null && evt.EventName.ToLower().Contains(query))
                    || (
                        evt.EventDescription != null
                        && evt.EventDescription.ToLower().Contains(query)
                    )
                    || (evt.EventLocation != null && evt.EventLocation.ToLower().Contains(query))
                    || (evt.EventCategory != null && evt.EventCategory.ToLower().Contains(query))
                )
                {
                    result.Add(evt);
                }
            }
            // Sort by event date
            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[i].EventDate > result[j].EventDate)
                    {
                        var temp = result[i];
                        result[i] = result[j];
                        result[j] = temp;
                    }
                }
            }
            return result;
        }

        public static void UpdateEventStatus(Guid eventId, EventStatus newStatus)
        {
            if (_eventLookup.TryGetValue(eventId, out Event evt))
            {
                evt.EventStatus = newStatus;
                _eventNotifications.Enqueue(
                    $"Event status updated: {evt.EventName} is now {newStatus}"
                );
            }
        }

        public static CustomDictionary<string, int> GetEventStatistics()
        {
            var stats = new CustomDictionary<string, int>();
            stats.Add("Total Events", _eventLookup.Count);

            int upcomingCount = 0;
            int ongoingCount = 0;
            int completedCount = 0;
            foreach (var evt in _eventLookup.Values)
            {
                if (evt.EventStatus == EventStatus.Upcoming)
                    upcomingCount++;
                else if (evt.EventStatus == EventStatus.Ongoing)
                    ongoingCount++;
                else if (evt.EventStatus == EventStatus.Completed)
                    completedCount++;
            }

            stats.Add("Upcoming Events", upcomingCount);
            stats.Add("Ongoing Events", ongoingCount);
            stats.Add("Completed Events", completedCount);
            stats.Add("Total Registrations", _registrationHistory.Count);
            stats.Add("User Interests", _userInterests.Count);

            return stats;
        }
    }
}
