using MassTransit;
using MassTransit.RabbitMqTransport;
using RSoft.Lib.Messaging.Options;
using System;

namespace RSoft.Lib.Messaging.Abstractions
{

    /// <summary>
    /// Dependency injection extensions
    /// </summary>
    public static class Factory
    {

        #region Public methods

        /// <summary>
        /// Configure bus control to transport message
        /// </summary>
        /// <param name="serverAddress">Message broker server address (host server)</param>
        /// <param name="virtualHost">Virtual host name</param>
        /// <param name="username">Username to connect</param>
        /// <param name="password">User password to connect</param>
        /// <param name="action">Registration actions</param>
        /// <exception cref="ArgumentNullException">Throws when serverAddress argument is null or empty</exception>
        public static IBusControl CreateUsingRabbitMq(string serverAddress, string virtualHost, string username, string password, Action<IRabbitMqBusFactoryConfigurator> action = null)
        {
            if (string.IsNullOrWhiteSpace(virtualHost))
                virtualHost = null;

            if (string.IsNullOrWhiteSpace(serverAddress)) throw new ArgumentNullException(nameof(serverAddress));

            string serverUri = $"rabbitmq://{serverAddress}/";
            if (!string.IsNullOrWhiteSpace(virtualHost))
                serverUri = $"{serverUri}{virtualHost}/";

            IBusControl bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {

                cfg.Host(serverUri, opt =>
                {
                    opt.Username(username);
                    opt.Password(password);
                });
                action?.Invoke(cfg);
            });

            return bus;

        }

        /// <summary>
        /// Configure bus control to transport message
        /// </summary>
        /// <param name="serverAddress">Message broker server address (host server)</param>
        /// <param name="username">Username to connect</param>
        /// <param name="password">User password to connect</param>
        /// <param name="action">Registration actions</param>
        /// <exception cref="ArgumentNullException">Throws when serverAddress argument is null or empty</exception>
        public static IBusControl CreateUsingRabbitMq(string serverAddress, string username, string password, Action<IRabbitMqBusFactoryConfigurator> action = null)
            => CreateUsingRabbitMq(serverAddress, null, username, password, action);

        /// <summary>
        /// Configure bus control to transport message
        /// </summary>
        /// <param name="options">Options configuration</param>
        /// <param name="action">Registration actions</param>
        /// <exception cref="ArgumentNullException">Throws when options argument is null reference</exception>
        public static IBusControl CreateUsingRabbitMq(MessagingOption options, Action<IRabbitMqBusFactoryConfigurator> action = null)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return CreateUsingRabbitMq(options.ServerAddress, options.VirtualHost, options.Username, options.Password, action);
        }

        #endregion

    }
}
