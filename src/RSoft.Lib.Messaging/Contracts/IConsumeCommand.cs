using MassTransit;

namespace RSoft.Lib.Messaging.Contracts
{

    /// <summary>
    /// Consumer command interface contract
    /// </summary>
    /// <typeparam name="TMessage">Message command type</typeparam>
    public interface IConsumeCommand<TMessage> : IConsumer<TMessage>
        where TMessage : class, IMessageCommand
    {
    }
}
