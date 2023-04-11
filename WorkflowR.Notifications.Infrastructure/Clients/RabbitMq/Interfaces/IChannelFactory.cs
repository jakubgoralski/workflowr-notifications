using RabbitMQ.Client;

namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;

public interface IChannelFactory
{
    IModel Create();
}