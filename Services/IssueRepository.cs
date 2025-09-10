using System;
using System.Collections.Generic;
using Municipality_App.Models;

namespace Municipality_App.Services
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
