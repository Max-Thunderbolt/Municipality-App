using System;
using Municipality_App.Models;
using Municipality_App.Structures;

namespace Municipality_App.Services
{
    public static class IssueRepository
    {
        private static readonly CustomList<IssueReport> _issues = new CustomList<IssueReport>();

        public static void Add(IssueReport issue)
        {
            _issues.Add(issue);
        }

        public static CustomList<IssueReport> GetAll()
        {
            return _issues.ToList();
        }
    }
}
