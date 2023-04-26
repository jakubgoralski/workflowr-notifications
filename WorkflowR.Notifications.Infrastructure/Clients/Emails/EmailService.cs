using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using WorkflowR.Notifications.Application.Emails.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.Emails.Options;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq;

namespace WorkflowR.Notifications.Application.Emails.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpAccessDetailsOption _options;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IOptions<SmtpAccessDetailsOption> options,
            ILogger<EmailService> logger)
        {
            _options = options.Value;
            _logger = logger;
        }
        public void Send(string emailTo, string subject, string content)
        {
            try
            {
                // TODO: Thanks to this we don't care about certificate. This can't be on PROD env.
                ServicePointManager.ServerCertificateValidationCallback =
                    (sender, certificate, chain, sslPolicyErrors) => true;

                SmtpClient smtpClient = new SmtpClient(_options.SmtpServer)
                {
                    EnableSsl = true,
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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
