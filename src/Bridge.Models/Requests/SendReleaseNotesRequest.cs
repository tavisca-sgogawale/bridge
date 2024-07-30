namespace Bridge.Models
{
    public class SendReleaseNotesRequest
    {
        public List<string> EmailIds { get; set; }
        public string TicketId { get; set; }
    }
}