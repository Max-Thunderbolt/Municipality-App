using System;
using System.Collections.Generic;

namespace Municipality_App.Models
{
    public enum EventStatus
    {
        Upcoming,
        Ongoing,
        Completed,
    }

    public class Event
    {
        public Guid EventId { get; set; } = Guid.NewGuid();
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string EventCategory { get; set; }
        public EventStatus EventStatus { get; set; }
    }
}
