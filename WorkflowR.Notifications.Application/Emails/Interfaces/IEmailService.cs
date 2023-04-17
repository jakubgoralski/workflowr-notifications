namespace WorkflowR.Notifications.Application.Emails.Interfaces
{
    public interface IEmailService
    {
        void Send(string email, string subject, string content);
    }
}
