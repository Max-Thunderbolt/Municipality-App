using System;
using System.Collections.Generic;
using System.Linq;
using Municipality_App.Models;

namespace Municipality_App.Services
{
    public static class EventService
    {
        // Priority Queue for event management - events sorted by date and priority
        private static readonly SortedDictionary<DateTime, List<Event>> _eventPriorityQueue =
            new SortedDictionary<DateTime, List<Event>>();

        // Hash Table for quick event lookup by ID
        private static readonly Dictionary<Guid, Event> _eventLookup =
            new Dictionary<Guid, Event>();

        // Stack for event registration history (LIFO)
        private static readonly Stack<EventRegistration> _registrationHistory =
            new Stack<EventRegistration>();

        // Set for tracking user interests
        private static readonly HashSet<string> _userInterests = new HashSet<string>();

        // Queue for event notifications
        private static readonly Queue<string> _eventNotifications = new Queue<string>();

        static EventService()
        {
            InitializeSampleEvents();
        }

        private static void InitializeSampleEvents()
        {
            var sampleEvents = new List<Event>
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
                _eventPriorityQueue[evt.EventDate.Date] = new List<Event>();
            }
            _eventPriorityQueue[evt.EventDate.Date].Add(evt);

            // Add to hash table for quick lookup
            _eventLookup[evt.EventId] = evt;

            // Add notification to queue
            _eventNotifications.Enqueue($"New event added: {evt.EventName}");
        }

        public static List<Event> GetUpcomingEvents()
        {
            var upcomingEvents = new List<Event>();
            var currentDate = DateTime.Now.Date;

            foreach (var kvp in _eventPriorityQueue)
            {
                if (kvp.Key >= currentDate)
                {
                    upcomingEvents.AddRange(
                        kvp.Value.Where(e => e.EventStatus == EventStatus.Upcoming)
                    );
                }
            }

            return upcomingEvents.OrderBy(e => e.EventDate).ToList();
        }

        public static List<Event> GetEventsByCategory(string category)
        {
            return _eventLookup
                .Values.Where(e =>
                    e.EventCategory.Equals(category, StringComparison.OrdinalIgnoreCase)
                )
                .OrderBy(e => e.EventDate)
                .ToList();
        }

        public static List<Event> GetEventsByLocation(string location)
        {
            return _eventLookup
                .Values.Where(e =>
                    e.EventLocation.Contains(location, StringComparison.OrdinalIgnoreCase)
                )
                .OrderBy(e => e.EventDate)
                .ToList();
        }

        public static Event GetEventById(Guid eventId)
        {
            return _eventLookup.TryGetValue(eventId, out Event evt) ? evt : null;
        }

        public static bool RegisterForEvent(
            Guid eventId,
            string userName,
            string userEmail,
            List<string> specialRequirements = null
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
                SpecialRequirements = specialRequirements ?? new List<string>(),
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

        public static List<EventRegistration> GetRegistrationHistory()
        {
            return _registrationHistory.ToList();
        }

        public static List<string> GetUserInterests()
        {
            return _userInterests.ToList();
        }

        public static List<string> GetEventNotifications()
        {
            var notifications = new List<string>();
            while (_eventNotifications.Count > 0)
            {
                notifications.Add(_eventNotifications.Dequeue());
            }
            return notifications;
        }

        public static List<Event> SearchEvents(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
                return GetUpcomingEvents();

            var query = searchQuery.ToLower();
            return _eventLookup
                .Values.Where(e =>
                    e.EventName.ToLower().Contains(query)
                    || e.EventDescription.ToLower().Contains(query)
                    || e.EventLocation.ToLower().Contains(query)
                    || e.EventCategory.ToLower().Contains(query)
                )
                .OrderBy(e => e.EventDate)
                .ToList();
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

        public static Dictionary<string, int> GetEventStatistics()
        {
            var stats = new Dictionary<string, int>
            {
                ["Total Events"] = _eventLookup.Count,
                ["Upcoming Events"] = _eventLookup.Values.Count(e =>
                    e.EventStatus == EventStatus.Upcoming
                ),
                ["Ongoing Events"] = _eventLookup.Values.Count(e =>
                    e.EventStatus == EventStatus.Ongoing
                ),
                ["Completed Events"] = _eventLookup.Values.Count(e =>
                    e.EventStatus == EventStatus.Completed
                ),
                ["Total Registrations"] = _registrationHistory.Count,
                ["User Interests"] = _userInterests.Count,
            };

            return stats;
        }
    }
}
