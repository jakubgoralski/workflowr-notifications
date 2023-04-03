using RabbitMQ.Client;

namespace WorkflowR.Notifications.Infrastructure.Clients.Provider.Interfaces
{
    internal interface IMessageBrokerModelProvider
    {
        IModel Get();
    }
}
