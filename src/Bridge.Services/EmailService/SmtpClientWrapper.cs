using Bridge.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Bridge.Services
{
    public class SmtpClientWrapper : ISmtpClientWrapper
    {
        private readonly ISmtpClient _client;
        public CancellationToken Token { get; set; }

        public SmtpClientWrapper()
        {
            _client = new SmtpClient();
        }

        public async Task ConnectAsyncWithSsl(MailSettings settings)
        {
            await _client.ConnectAsync(settings.Host, settings.Port, SecureSocketOptions.SslOnConnect, Token);
        }

        public async Task ConnectAsyncWithTls(MailSettings settings)
        {
            await _client.ConnectAsync(settings.Host, settings.Port, SecureSocketOptions.StartTls, Token);
        }

        public async Task AuthenticateWithSmtp(MailSettings settings)
        {
            await _client.AuthenticateAsync(settings.UserName, settings.Password, Token);
        }

        public async Task<string> SendMail(MimeMessage email)
        {
            return await _client.SendAsync(email, Token);
        }

        public async Task DisconnectClient()
        {
            await _client.DisconnectAsync(true, Token);
        }
    }
}
