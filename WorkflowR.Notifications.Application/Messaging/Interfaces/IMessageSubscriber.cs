﻿namespace WorkflowR.Notifications.Application.Messaging.Interfaces
{
    public interface IMessageSubscriber
    {
        void Subscribe(Action<EmailObject> action);
    }
}
