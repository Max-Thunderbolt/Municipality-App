using System;
using Municipality_App.Structures;

namespace Municipality_App.Models
{
    public class EventRegistration
    {
        public Guid RegistrationId { get; set; } = Guid.NewGuid();
        public Guid EventId { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool IsConfirmed { get; set; }
        public CustomList<string> SpecialRequirements { get; set; } = new CustomList<string>();
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
