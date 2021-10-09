using RSoft.Lib.Common.Enums;
using RSoft.Lib.Messaging.Contracts;
using System;

namespace RSoft.Lib.Contracts.Events
{

    /// <summary>
    /// Occurs when an user is created/added.
    /// </summary>
    public class UserCreatedEvent : IMessageEvent
    {

        #region Constructors

        /// <summary>
        /// Create a new event instance
        /// </summary>
        /// <param name="id">User id key value</param>
        /// <param name="firstName">User first name</param>
        /// <param name="lastName">User last name</param>
        /// <param name="email">User e-mail address</param>
        /// <param name="bornDate">User date of birth</param>
        /// <param name="type">User type</param>
        /// <param name="isActive">Active status flag</param>
        public UserCreatedEvent(Guid id, string firstName, string lastName, string email, DateTime? bornDate, UserType type, bool isActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BornDate = bornDate;
            Type = type;
            IsActive = isActive;
        }
        
        #endregion

        #region Properties


        /// <summary>
        /// User id key value
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// User e-mail
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// User's date of birth
        /// </summary>
        public DateTime? BornDate { get; private set; }

        /// <summary>
        /// User type
        /// </summary>
        public UserType Type { get; private set; }

        /// <summary>
        /// Active status flag
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

    }
}
