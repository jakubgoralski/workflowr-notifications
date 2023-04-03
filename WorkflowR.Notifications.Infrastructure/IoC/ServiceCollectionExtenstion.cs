using Microsoft.Extensions.DependencyInjection;
using WorkflowR.Notifications.Infrastructure.Clients;
using WorkflowR.Notifications.Infrastructure.Clients.Interfaces;
using RabbitMQ.Client;
using WorkflowR.Notifications.Infrastructure.Clients.Provider.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.Providers;

namespace WorkflowR.Notifications.Infrastructure.IoC
{
    public static class ServiceCollectionExtenstion
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // RabbitMq
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            // Message Broker
            services.AddSingleton<IMessageBrokerModelProvider, MessageBrokerModelProvider>();
            services.AddSingleton<IMessageBrokerProducer, MessageBrokerProducer>();
            services.AddSingleton<IMessageBrokerSubscriber, MessageBrokerSubscriber>();

            return services;
        }
    }
}
