using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Lib.Messaging.Options;
using System;

namespace RSoft.Lib.Messaging.Abstractions
{

    /// <summary>
    /// Dependency injection abstraction methods
    /// </summary>
    public static class DependencyInjection
    {
        
        /// <summary>
        /// Add MassTransition using RabbitMQ transport and register consumers
        /// </summary>
        /// <param name="services">Service collection container</param>
        /// <param name="serverAddress">Message broker server address (host server)</param>
        /// <param name="virtualHost">Virtual host name</param>
        /// <param name="username">Username to connect</param>
        /// <param name="password">User password to connect</param>
        /// <param name="configure">Configura registration actions</param>
        /// <returns></returns>
        public static IServiceCollection AddMassTransitUsingRabbitMq(this IServiceCollection services, string serverAddress, string virtualHost, string username, string password, Action<IRabbitMqBusFactoryConfigurator> configure = null)
        {

            services.AddMassTransit(busConfiguration =>
            {
                
                busConfiguration.UsingRabbitMq((context, cfg) =>
                {

                    string serverUrl = $"rabbitmq://{serverAddress}/";
                    if (!string.IsNullOrWhiteSpace(virtualHost))
                        serverUrl += $"{virtualHost}";

                    cfg.Host(serverUrl, opt =>
                    {
                        opt.Username(username);
                        opt.Password(password);
                    });
                    cfg.ConfigureEndpoints(context);

                    configure?.Invoke(cfg);

                });

            });

            services.AddMassTransitHostedService(true);

            return services;
        }

        /// <summary>
        /// Add MassTransition using RabbitMQ transport and register consumers
        /// </summary>
        /// <param name="services">Service collection container</param>
        /// <param name="serverAddress">Message broker server address (host server)</param>
        /// <param name="username">Username to connect</param>
        /// <param name="password">User password to connect</param>
        /// <param name="configure">Configura registration actions</param>
        public static IServiceCollection AddMassTransitUsingRabbitMq(this IServiceCollection services, string serverAddress, string username, string password, Action<IRabbitMqBusFactoryConfigurator> configure = null)
            => AddMassTransitUsingRabbitMq(services, serverAddress, null, username, password, configure);

        /// <summary>
        /// Add MassTransition using RabbitMQ transport and register consumers
        /// </summary>
        /// <param name="services">Service collection container</param>
        /// <param name="options">Options configuration</param>
        /// <param name="configure">Configura registration actions</param>
        public static IServiceCollection AddMassTransitUsingRabbitMq(this IServiceCollection services, MessagingOption options, Action<IRabbitMqBusFactoryConfigurator> configure = null)
            => AddMassTransitUsingRabbitMq(services, options.ServerAddress, options.VirtualHost, options.Username, options.Password, configure);

        /// <summary>
        /// Add MassTransition using RabbitMQ transport and register consumers
        /// </summary>
        /// <param name="services">Service collection container</param>
        /// <param name="configuration">Configuration collection object</param>
        /// <param name="configure">Configura registration actions</param>
        public static IServiceCollection AddMassTransitUsingRabbitMq(this IServiceCollection services, IConfiguration configuration, Action<IRabbitMqBusFactoryConfigurator> configure = null)
            => AddMassTransitUsingRabbitMq(services, configuration, null, configure);

        /// <summary>
        /// Add MassTransition using RabbitMQ transport and register consumers
        /// </summary>
        /// <param name="services">Service collection container</param>
        /// <param name="configuration">Configuration collection object</param>
        /// <param name="configSection">Message options server configuration server name in appconfig</param>
        /// <param name="configure">Configura registration actions</param>
        public static IServiceCollection AddMassTransitUsingRabbitMq(this IServiceCollection services, IConfiguration configuration, string configSection, Action<IRabbitMqBusFactoryConfigurator> configure = null)
        {
            configSection ??= "Messaging:Server";
            MessagingOption options = new MessagingOption();
            configuration.GetSection(configSection).Bind(options);
            return AddMassTransitUsingRabbitMq(services, options.ServerAddress, options.VirtualHost, options.Username, options.Password, configure);
        }

    }
}
