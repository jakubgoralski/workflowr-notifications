using WorkflowR.Notifications.Infrastructure.Clients.Emails.Options;

namespace WorkflowR.Notifications.Infrastructure.IoC
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpAccessDetailsOption>(configuration.GetSection(nameof(SmtpAccessDetailsOption)));

            return services;
        }
    }
}
