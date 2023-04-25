using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkflowR.Notifications.Application.Emails.Interfaces;
using WorkflowR.Notifications.Application.Messaging.Interfaces;

namespace WorkflowR.Notifications.Application.Messaging.Services
{
    public class MessageConsumerHostedService : BackgroundService
    {
        private readonly ILogger<MessageConsumerHostedService> _logger;
        private readonly IMessageSubscriber _messageSubscriber;
        private readonly IEmailService _emailService;

        public MessageConsumerHostedService(
            ILogger<MessageConsumerHostedService> logger,
            IMessageSubscriber messageSubscriber,
            IEmailService emailService)
        {
            _logger = logger;
            _messageSubscriber = messageSubscriber;
            _emailService = emailService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _messageSubscriber.Subscribe((msg) =>
            {
                _logger.LogInformation($"BCK SERVICE {msg} is received");
                _emailService.Send("jakubgoralski95@gmail.com", "WorkflowR Test", "Content Test");
            });

            return Task.CompletedTask;
        }
    }
}
