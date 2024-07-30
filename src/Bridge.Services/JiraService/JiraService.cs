using Bridge.Models;


namespace Bridge.Services
{

    public class JiraServices: IJiraService
    {
        public async Task<IssueDetail> GetIssueDetailAsync(string issueKey)
        {

            //TODO: Get mock data for jira tickets
            return new IssueDetail();
        }

        private string GenerateAuthToken(string userName, string password)
        {
            var credentials = userName + ":" + password;
            var credentialsBytes = System.Text.Encoding.UTF8.GetBytes(credentials);
            var authToken = "Basic " + Convert.ToBase64String(credentialsBytes);
            return authToken;
        }
    }
}
