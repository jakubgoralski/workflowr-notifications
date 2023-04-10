using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;
using System.Text;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Providers.Interfaces;

namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq
{
    internal class MessageBrokerSubscriber : IMessageBrokerSubscriber
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ILogger<MessageBrokerSubscriber> _logger;

        public MessageBrokerSubscriber(
            ILogger<MessageBrokerSubscriber> logger,
            IChannelFactory channelFactory)
        {
            _channel = channelFactory.Create();
            _logger = logger;
        }

        public void Subscribe(Action<string> action)
        {
            _channel.ExchangeDeclare("jgexchange", "topic");
            _channel.QueueDeclare("jgqueue");
            _channel.QueueBind("jgqueue", "jgexchange", "jgroutingkey");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation($"SUBCRIBER {message} message has been received.");

                action(message);

                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            string consumerTag = _channel.BasicConsume("jgqueue", autoAck: false, consumer);
        }
    }
}
