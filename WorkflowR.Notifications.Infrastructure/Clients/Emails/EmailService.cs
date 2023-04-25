using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using WorkflowR.Notifications.Application.Emails.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.Emails.Options;

namespace WorkflowR.Notifications.Application.Emails.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpAccessDetailsOption _options;

        public EmailService(IOptions<SmtpAccessDetailsOption> options)
        {
            _options = options.Value;
        }
        public void Send(string emailTo, string subject, string content)
        {
            SmtpClient smtpClient = new SmtpClient(_options.SmtpServer)
            {
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential(_options.Email, _options.Password)
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_options.Email),
                Subject = subject,
                Body = content,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(emailTo);

            smtpClient.Send(mailMessage);
        }
    }
}
