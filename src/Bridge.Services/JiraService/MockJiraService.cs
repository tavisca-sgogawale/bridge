using Bridge.Models;
using Newtonsoft.Json;

namespace Bridge.Services
{

    public class MockJiraServices: IJiraService
    {
        public async Task<IssueDetail> GetIssueDetailAsync(string issueKey)
        {

            var baseDirectory = AppContext.BaseDirectory;
            var filePath = $"{baseDirectory}/JiraService/MockData/{issueKey}.json";
            if (File.Exists(filePath))
            {
                var data = File.ReadAllText(filePath);
                if (data != null)
                   return JsonConvert.DeserializeObject<IssueDetail>(data);
            }
            return new IssueDetail();
        }

      
    }
}
