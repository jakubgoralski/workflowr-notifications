namespace WorkflowR.Notifications.Infrastructure.Clients.Emails.Options
{
    public sealed class SmtpAccessDetailsOption
    {
        public string SmtpServer { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
