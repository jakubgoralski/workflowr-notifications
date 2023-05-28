using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;
using WorkflowR.Notifications.Application.Messaging.Interfaces;
using WorkflowR.Notifications.Application.Messaging;
using System.Text.Json;

namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq
{
    internal class RabbitMqMessageSubscriber : IMessageSubscriber
    {
        private readonly IModel _channel;
        private readonly ILogger<RabbitMqMessageSubscriber> _logger;

        public RabbitMqMessageSubscriber(
            ILogger<RabbitMqMessageSubscriber> logger,
            IChannelFactory channelFactory)
        {
            _channel = channelFactory.Create();
            _logger = logger;
        }

        public void Subscribe(Action<EmailObject> action)
        {
            _channel.ExchangeDeclare("jgexchange", "topic");
            _channel.QueueDeclare("jgqueue");
            _channel.QueueBind("jgqueue", "jgexchange", "jgroutingkey");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var emailobject = JsonSerializer.Deserialize<EmailObject>(body);
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation($"SUBCRIBER {emailobject.message} message has been received.");

                action(emailobject);

                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            string consumerTag = _channel.BasicConsume("jgqueue", autoAck: false, consumer);
        }
    }
}
