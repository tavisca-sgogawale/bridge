namespace Bridge.Models
{
    public class JiraConfiguration
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Url { get; set; }
        public string BaseUrl { get; set; }
        public int? TimeOutInMilliSeconds { get; set; }
    }
}