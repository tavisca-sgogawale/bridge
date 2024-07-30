using Bridge.Models;
using Microsoft.AspNetCore.Http;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISmtpClientWrapper _smtpClientWrapper;
        private readonly IJiraService _jiraService;
        private MailSettings _settings;
        public EmailService(ISmtpClientWrapper smtpClientWrapper, IJiraService jiraService)
        {
            _smtpClientWrapper = smtpClientWrapper;
            _jiraService = jiraService;
        }
        public async Task<bool> SendReleaseNotesByJiraId(SendReleaseNotesRequest request, CancellationToken ct = default)
        {

            Email mailData = new Email();
            // Initialize a new instance of the MimeKit.MimeMessage class
            var mail = new MimeMessage();
            _settings = await FetchMailSettings();
            _smtpClientWrapper.Token = ct;

            #region Sender / Receiver
            // Sender
            mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

            // Receiver
            foreach (string mailAddress in mailData.To)
                mail.To.Add(MailboxAddress.Parse(mailAddress));

            // BCC
            // Check if a BCC was supplied in the request
            if (mailData.Bcc != null)
            {
                // Get only addresses where value is not null or with whitespace. x = value of address
                foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }

            // CC
            // Check if a CC address was supplied in the request
            if (mailData.Cc != null)
            {
                foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                    mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
            }
            #endregion

            #region Content
            // Add Content to Mime Message
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;

            body.HtmlBody = await FetchMailBody(mailData);

            // Add attachments
            if (mailData.Attachments != null)
            {
                AddAttachments(body, mailData.Attachments);
            }

            mail.Body = body.ToMessageBody();
            #endregion

            #region Send Mail

            if (_settings.UseSSL)
            {
                await _smtpClientWrapper.ConnectAsyncWithSsl(_settings);
            }
            else if (_settings.UseStartTls)
            {
                await _smtpClientWrapper.ConnectAsyncWithTls(_settings);
            }

            await _smtpClientWrapper.AuthenticateWithSmtp(_settings);
            await _smtpClientWrapper.SendMail(mail);
            await _smtpClientWrapper.DisconnectClient();

            return true;
            #endregion
        }

        private void AddAttachments(BodyBuilder body, IFormFileCollection Attachments)
        {
            foreach (var file in Attachments)
            {
                body.Attachments.Add(Convert.ToString(file.FileName), file.OpenReadStream(), ContentType.Parse(file.ContentType));
            }
        }

        private async Task<MailSettings> FetchMailSettings()
        {
            return new MailSettings()
            {
                DisplayName = "Site Manager",
                From = "sgogawale@tavisca.com",
                Host = "email-smtp.us-east-1.amazonaws.com",
                Port = 587,
                UserName = "[#sitemanager-aws-email-username#]",
                Password = "[#sitemanager-aws-email-password#]",
                UseSSL = false,
                UseStartTls = true
            };
        }

        private async Task<string> FetchMailBody(Email mailData)
        {
          //TODO: Get static html template to dump release notes
          return "";
        }
    }
}
