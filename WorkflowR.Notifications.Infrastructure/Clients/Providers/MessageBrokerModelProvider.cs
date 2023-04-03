using RabbitMQ.Client;
using WorkflowR.Notifications.Infrastructure.Clients.Provider.Interfaces;

namespace WorkflowR.Notifications.Infrastructure.Clients.Providers
{
    internal class MessageBrokerModelProvider : IMessageBrokerModelProvider
    {
        private IConnection _connection { get; }

        internal MessageBrokerModelProvider(IConnectionFactory connectionFactory)
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
