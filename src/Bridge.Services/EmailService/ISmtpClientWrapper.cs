using Bridge.Models;
using MimeKit;


namespace Bridge.Services
{
    public interface ISmtpClientWrapper
    {
        CancellationToken Token { get; set; }
        Task ConnectAsyncWithSsl(MailSettings settings);
        Task ConnectAsyncWithTls(MailSettings settings);
        Task AuthenticateWithSmtp(MailSettings settings);
        Task<string> SendMail(MimeMessage email);
        Task DisconnectClient();
    }
}
