using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq.Interfaces;
using WorkflowR.Notifications.Infrastructure.Clients.RabbitMq;
using WorkflowR.Notifications.Application.Messaging.Interfaces;
using WorkflowR.Notifications.Application.Emails.Interfaces;
using WorkflowR.Notifications.Application.Emails.Services;

namespace WorkflowR.Notifications.Infrastructure.IoC
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Email
            services.AddTransient<IEmailService, EmailService>();

            // RabbitMq
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            services.AddSingleton(connection);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<ChannelAccessor>();
            services.AddSingleton<IChannelFactory, ChannelFactory>();

            // Message Broker
            services.AddSingleton<IMessageBrokerProducer, MessageBrokerProducer>();
            services.AddSingleton<IMessageSubscriber, RabbitMqMessageSubscriber>();

            return services;
        }
    }
}
