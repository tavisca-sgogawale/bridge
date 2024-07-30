using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Services
{
    public static class JiraServiceConstants
    {
        public static class IssueLinksType
        {
            public const string ReleaseCandidate = "Release Candidate";
            public const string IsDependentOnCandidate = "Dependency"; //"is dependent on";
            public const string IncludesHotfixes = "Includes Hotfixes";
            public const string HotfixFor = "Hotfix For";
            public const string Bug = "bug";
            public const string Release = "Release";
            public const string Test = "Test";
        }

        public static class Labels
        {
            public const string Hotfix = "hotfix";
        }
    }
}
