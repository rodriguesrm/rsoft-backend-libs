using MassTransit;
using MassTransit.RabbitMqTransport;
using RSoft.Lib.Messaging.Contracts;
using System;
using System.Threading.Tasks;

namespace RSoft.Lib.Messaging.Extensions
{

    /// <summary>
    /// Extension methods for MassitTransitions bus object
    /// </summary>
    public static class MassitTransitionExtension
    {

        /// <summary>
        /// Make queue Uri endpoint
        /// </summary>
        /// <typeparam name="TMessage">Message type to compose uri</typeparam>
        /// <param name="bus">Message bus control</param>
        /// <param name="queueName">Queue name</param>
        public static Uri MakeQueueUri<TMessage>(this IBusControl bus, string queueName = null)
            where TMessage : class
        {
            int segmentPosition = 0;
            if (bus.Address.Segments.Length >= 2)
                segmentPosition = (bus.Address.Segments.Length - 2);

            queueName ??= typeof(TMessage).Name;

            string url = $"rabbitmq://{bus.Address.Host}/{bus.Address.Segments[segmentPosition]}/{queueName}";
            return new Uri(url);
        }

        /// <summary>
        /// Send a command message
        /// </summary>
        /// <typeparam name="TCommand">Command type</typeparam>
        /// <param name="bus">Message bus control</param>
        /// <param name="messageCommand"></param>
        /// <param name="queueName">Queue name</param>
        public static async Task SendCommand<TCommand>(this IBusControl bus, TCommand messageCommand, string queueName = null)
            where TCommand : class, IMessageCommand
        {
            ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(bus.MakeQueueUri<TCommand>(queueName));
            await sendEndpoint.Send(messageCommand);
        }

        /// <summary>
        /// PUblick a event message
        /// </summary>
        /// <typeparam name="TEvent">Event type</typeparam>
        /// <param name="endpoint"></param>
        /// <param name="messageEvent"></param>
        /// <returns></returns>
        public static Task RaiseEvent<TEvent>(this IPublishEndpoint endpoint, TEvent messageEvent)
            => endpoint.Publish(messageEvent);

        /// <summary>
        /// Register command consumer endpoint
        /// </summary>
        /// <typeparam name="TCommand">Command type</typeparam>
        /// <typeparam name="TConsumer">Consumer type</typeparam>
        /// <param name="config">RabbitMQ Bus factory configurator</param>
        /// <param name="queueName">Queue name</param>
        public static void AddCommandConsumerEndpoint<TCommand, TConsumer>(this IRabbitMqBusFactoryConfigurator config, string queueName = null)
            where TConsumer : class, IConsumer
            where TCommand : class, IMessageCommand
        {

            queueName ??= typeof(TCommand).Name;
            config.ReceiveEndpoint(queueName, e =>
            {
                e.Consumer(() => Activator.CreateInstance<TConsumer>()); ;
            });

        }

        /// <summary>
        /// Register event consumer endpoint
        /// </summary>
        /// <typeparam name="TCommand">Event type</typeparam>
        /// <typeparam name="TConsumer">Consumer type</typeparam>
        /// <param name="config">RabbitMQ Bus factory configurator</param>
        /// <param name="queueName">Queue name</param>
        public static void AddEventConsumerEndpoint<TEvent, TConsumer>(this IRabbitMqBusFactoryConfigurator config, string queueName = null)
            where TConsumer : class, IConsumer
            where TEvent : class, IMessageEvent
        {

            queueName ??= $"{typeof(TEvent).Name}-{typeof(TConsumer).Name}";
            config.ReceiveEndpoint(queueName, e =>
            {
                e.Consumer(() => Activator.CreateInstance<TConsumer>()); ;
            });

        }

    }
}
