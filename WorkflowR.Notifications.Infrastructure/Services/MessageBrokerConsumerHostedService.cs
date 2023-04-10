using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;

namespace WorkflowR.Notifications.Infrastructure.Services
{
    public class MessageBrokerConsumerHostedService : BackgroundService
    {
        private readonly ILogger<MessageBrokerConsumerHostedService> _logger;
        private readonly IMessageBrokerSubscriber _messageSubscriber;

        public MessageBrokerConsumerHostedService(
            ILogger<MessageBrokerConsumerHostedService> logger,
            IMessageBrokerSubscriber messageSubscriber)
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
