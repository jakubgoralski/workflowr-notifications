using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WorkflowR.Notifications.Infrastructure.Clients.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.Provider.Interfaces;

namespace WorkflowR.Notifications.Infrastructure.Clients
{
    internal class MessageBrokerSubscriber : IMessageBrokerSubscriber
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBrokerSubscriber(IMessageBrokerModelProvider messageBrokerModelProvider)
        {
            _channel = messageBrokerModelProvider.Get();
        }

        public void Subscribe(Action<string> action)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                string body = ea.Body.ToArray().ToString();
                action(body);
                // copy or deserialise the payload
                // and process the message
                // ...
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            // this consumer tag identifies the subscription
            // when it has to be cancelled
            string consumerTag = _channel.BasicConsume("jgtest", false, consumer);
        }
    }
}
