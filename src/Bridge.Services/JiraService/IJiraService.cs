using Bridge.Models;

namespace Bridge.Services
{
    public interface IJiraService
    {
        public Task<IssueDetail> GetIssueDetailAsync(string issueKey);
    }
}
