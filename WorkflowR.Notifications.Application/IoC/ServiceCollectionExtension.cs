using Microsoft.Extensions.DependencyInjection;
using WorkflowR.Notifications.Application.Messaging.Services;

namespace WorkflowR.Notifications.Application.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHostedService<MessageConsumerHostedService>();

            return services;
        }
    }
}
