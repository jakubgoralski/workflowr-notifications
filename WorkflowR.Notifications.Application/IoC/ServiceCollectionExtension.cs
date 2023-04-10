using Microsoft.Extensions.DependencyInjection;
using WorkflowR.Notifications.Application.Services;

namespace WorkflowR.Notifications.Application.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHostedService<MessageBrokerConsumerHostedService>();

            return services;
        }
    }
}
