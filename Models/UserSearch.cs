using System;
using Municipality_App.Structures;

namespace Municipality_App.Models
{
    public class UserSearch
    {
        public Guid SearchId { get; set; } = Guid.NewGuid();
        public DateTime SearchTimestamp { get; set; } = DateTime.Now;
        public string SearchQuery { get; set; }
        public string SearchCategory { get; set; }
        public string SearchLocation { get; set; }
        public int ResultCount { get; set; }
        public CustomList<string> SearchFilters { get; set; } = new CustomList<string>();
        public bool WasSuccessful { get; set; }
    }
}
