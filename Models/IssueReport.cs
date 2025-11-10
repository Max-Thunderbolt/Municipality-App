using System;
using Municipality_App.Structures;

namespace Municipality_App.Models
{
    public class IssueReport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public CustomList<string> AttachmentFilePaths { get; set; } = new CustomList<string>();
    }
}
