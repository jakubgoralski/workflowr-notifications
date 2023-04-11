using RabbitMQ.Client;

namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Providers.Interfaces
{
    public interface IMessageBrokerModelProvider
    {
        IModel Get();
    }
}
