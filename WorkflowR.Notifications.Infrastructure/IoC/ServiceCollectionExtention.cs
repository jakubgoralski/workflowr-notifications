using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq;
using WorkflowR.Notifications.Infrastructure.Services;

namespace WorkflowR.Notifications.Infrastructure.IoC
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // RabbitMq
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            services.AddSingleton(connection);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<ChannelAccessor>();
            services.AddSingleton<IChannelFactory, ChannelFactory>();

            // Message Broker
            services.AddSingleton<IMessageBrokerProducer, MessageBrokerProducer>();
            services.AddSingleton<IMessageBrokerSubscriber, MessageBrokerSubscriber>();
            services.AddHostedService<MessageBrokerConsumerHostedService>();

            return services;  
        }
    }
}
