using System;
using System.Collections.Generic;

namespace Municipality_App
{
    public static class IssueRepository
    {
        private static readonly List<IssueReport> _issues = new List<IssueReport>();

        public static void Add(IssueReport issue)
        {
            _issues.Add(issue);
        }

        public static IReadOnlyList<IssueReport> GetAll()
        {
            return _issues.AsReadOnly();
        }
    }
}
