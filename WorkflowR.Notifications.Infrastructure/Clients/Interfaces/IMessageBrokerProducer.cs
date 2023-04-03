namespace WorkflowR.Notifications.Infrastructure.Clients.Interfaces
{
    internal interface IMessageBrokerProducer
    {
        void Publish(string message);
    }
}
