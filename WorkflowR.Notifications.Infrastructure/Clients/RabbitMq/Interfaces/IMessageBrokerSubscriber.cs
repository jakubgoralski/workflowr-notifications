namespace WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces
{
    public interface IMessageBrokerSubscriber
    {
        void Subscribe(Action<string> action);
    }
}
