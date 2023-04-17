using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkflowR.Notifications.Application.Messaging.Interfaces;

namespace WorkflowR.Notifications.Application.Messaging.Services
{
    public class MessageConsumerHostedService : BackgroundService
    {
        private readonly ILogger<MessageConsumerHostedService> _logger;
        private readonly IMessageSubscriber _messageSubscriber;

        public MessageConsumerHostedService(
            ILogger<MessageConsumerHostedService> logger,
            IMessageSubscriber messageSubscriber)
        {
            _logger = logger;
            _messageSubscriber = messageSubscriber;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _messageSubscriber.Subscribe((msg) =>
            {
                _logger.LogInformation($"BCK SERVICE {msg} is received");
            });

            return Task.CompletedTask;
        }
    }
}
