using RSoft.Lib.Messaging.Contracts;
using System;

namespace RSoft.Lib.Contracts.Events
{

    /// <summary>
    /// Occurs when an user is removed/deleted.
    /// </summary>
    public class UserDeletedEvent : IMessageEvent
    {

        #region Constructors

        /// <summary>
        /// Create a new event instance
        /// </summary>
        /// <param name="id">User id key value</param>
        public UserDeletedEvent(Guid id)
        {
            Id = id;
        }
        
        #endregion

        #region Properties


        /// <summary>
        /// User id key value
        /// </summary>
        public Guid Id { get; private set; }

        #endregion

    }
}
