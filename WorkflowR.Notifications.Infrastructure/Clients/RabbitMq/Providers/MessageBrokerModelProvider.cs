using RabbitMQ.Client;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Providers.Interfaces;

namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Providers
{
    public class MessageBrokerModelProvider : IMessageBrokerModelProvider
    {
        private IConnection _connection { get; }

        public MessageBrokerModelProvider(IConnectionFactory connectionFactory)
        {
            connectionFactory.UserName = "guest";
            connectionFactory.Password = "guest";
            connectionFactory.VirtualHost = "rabbitmq";

            connectionFactory.Uri = new Uri("amqp://user:pass@localhost:port/vhost");

            IConnection connection = connectionFactory.CreateConnection();
        }

        public IModel Get()
        {
            return _connection.CreateModel();
        }
    }
}
