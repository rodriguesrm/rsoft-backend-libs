﻿using MassTransit;

namespace RSoft.Lib.Messaging.Contracts
{

    /// <summary>
    /// Consumer event interface contract
    /// </summary>
    /// <typeparam name="TMessage">Message event type</typeparam>
    public interface IConsumeEvent<TMessage> : IConsumer<TMessage>
        where TMessage : class, IMessageEvent
    {
    }
}
