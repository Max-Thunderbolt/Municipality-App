using System;
using System.Collections.Generic;

namespace Municipality_App
{
    public class IssueReport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> AttachmentFilePaths { get; set; } = new List<string>();
    }
}
