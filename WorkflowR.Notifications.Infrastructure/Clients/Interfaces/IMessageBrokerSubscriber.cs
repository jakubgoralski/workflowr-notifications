namespace WorkflowR.Notifications.Infrastructure.Clients.Interfaces
{
    internal interface IMessageBrokerSubscriber
    {
        void Subscribe(Action<string> action);
    }
}
