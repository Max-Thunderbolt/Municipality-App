using System;
using System.Collections.Generic;

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
        public List<string> SearchFilters { get; set; } = new List<string>();
        public bool WasSuccessful { get; set; }
    }
}
