using RabbitMQ.Client;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Providers.Interfaces;

namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq
{
    public class MessageBrokerProducer : IMessageBrokerProducer
    {
        private readonly IModel _channel;

        public MessageBrokerProducer(IChannelFactory channelFactory)
        {
            _channel = channelFactory.Create();
        }
        public void Publish(string message)
        {
            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(message);
            _channel.ExchangeDeclare("jgexchange", "topic", false, false);
            _channel.BasicPublish("jgexchange", "jgroutingkey", true, _channel.CreateBasicProperties(), messageBodyBytes);
        }
    }
}
