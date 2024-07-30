using Microsoft.AspNetCore.Http;

namespace Bridge.Models
{
    public class Email
    {
        // Receiver
        public List<string> To { get; set; }

        public List<string> Bcc { get; set; }
        public List<string> Cc { get; set; }

        // Sender
        public string? From { get; set; }

        public string? DisplayName { get; set; }

        // Content
        public string Subject { get; set; }

        public string EmailType { get; set; }
        public string? Body { get; set; }
        public object TemplateModel { get; set; }
        public bool FetchFromExternalSource { get; set; }
        public IDictionary<string, string> TemplateParameters { get; set; }

        // Attachment
        public IFormFileCollection Attachments { get; set; }
    }
}