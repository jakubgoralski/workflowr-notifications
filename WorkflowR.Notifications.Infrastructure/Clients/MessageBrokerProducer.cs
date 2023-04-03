using RabbitMQ.Client;
using WorkflowR.Notifications.Infrastructure.Clients.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.Provider.Interfaces;

namespace WorkflowR.Notifications.Infrastructure.Clients
{
    internal class MessageBrokerProducer : IMessageBrokerProducer
    {
        private readonly IModel _channel;

        public MessageBrokerProducer(IMessageBrokerModelProvider messageBrokerModelProvider)
        {
            _channel = messageBrokerModelProvider.Get();
        }

        public void Publish(string message)
        {
            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(ExchangeType.Direct, "jgtest", null, messageBodyBytes);
        }
    }
}
