namespace Bridge.Models
{
    public class IssueDetail
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public Fields Fields { get; set; }
    }

    public class Fields
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public List<Issuelink> Issuelinks { get; set; } = new List<Issuelink>();
        public IssueStatusDetail Status { get; set; }
        public List<string> Labels { get; set; }
        public Issuetype Issuetype { get; set; }
    }

    public class Issuelink
    {
        public IssueType Type { get; set; }
        public OutwardIssue OutwardIssue { get; set; }
        public InwardIssue InwardIssue { get; set; }
    }

    public class IssueType
    {
        public string Name { get; set; }
    }

    public class OutwardIssue
    {
        public string Key { get; set; }
        public OutwardIssueFields Fields { get; set; }
    }

    public class OutwardIssueFields
    {
        public Issuetype Issuetype { get; set; }
        public Status Status { get; set; }
    }

    public class Status
    {
        public string Name { get; set; }
    }

    public class Issuetype
    {
        public string Name { get; set; }
    }

    public class InwardIssue
    {
        public string Key { get; set; }
        public InwardIssueFields Fields { get; set; }
    }

    public class InwardIssueFields
    {
        public Issuetype Issuetype { get; set; }

        public Status Status { get; set; }
    }

    public class IssueStatusDetail
    {
        public string Self { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
    }
}