namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces
{
    public interface IMessageBrokerProducer
    {
        void Publish(string message);
    }
}
