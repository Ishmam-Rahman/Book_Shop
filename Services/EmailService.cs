using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using BookStroe.ViewModel;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BookStroe.Services
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"EmailTemplate/{0}.html";

        private readonly SMTPConfigViewModel _SMTPConfig;

        public async Task SendTestEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = "I am omi using you for my email service teste!!! :P";
            userEmailOptions.Body = GetEmailBody("TestEmail");

            await SendEmail(userEmailOptions);
        }
        public EmailService(IOptions<SMTPConfigViewModel> options)
        {
            _SMTPConfig = options.Value;
        }



        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_SMTPConfig.SenderAddress, _SMTPConfig.SenderDisplayName),
                IsBodyHtml = _SMTPConfig.IsBodyHTML
            };

            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_SMTPConfig.UserName, _SMTPConfig.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _SMTPConfig.Host,
                Port = _SMTPConfig.Port,
                EnableSsl = _SMTPConfig.EnableSSL,
                UseDefaultCredentials = _SMTPConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };

            mail.BodyEncoding = Encoding.Default;

            await smtpClient.SendMailAsync(mail);
        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(String.Format(templatePath, templateName));
            return body;
        }
    }
}
