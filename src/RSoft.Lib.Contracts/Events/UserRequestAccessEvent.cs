using RSoft.Lib.Messaging.Contracts;
using System;

namespace RSoft.Lib.Contracts.Events
{

    /// <summary>
    /// Occurs when an user request new or reset access.
    /// </summary>
    public class UserRequestAccessEvent : IMessageEvent
    {


        #region Constructors

        /// <summary>
        /// Create a new event instance
        /// </summary>
        /// <param name="firstAccess">Indicates whether this is first access</param>
        /// <param name="name">Recipient's full name</param>
        /// <param name="email">Recipient's Email</param>
        /// <param name="token">Password creation/reset token</param>
        /// <param name="expireOn">Date and time the token will expire</param>
        /// <param name="urlCredential">URL of the credential creation/reset page</param>
        public UserRequestAccessEvent(bool firstAccess, string name, string email, Guid token, DateTime expireOn, string urlCredential)
        {
            FirstAccess = firstAccess;
            Name = name;
            Email = email;
            Token = token;
            ExpireOn = expireOn;
            UrlCredential = urlCredential;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether this is first access
        /// </summary>
        public bool FirstAccess { get; private set; }

        /// <summary>
        /// Recipient's full name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Recipient's Email
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Password creation/reset token
        /// </summary>
        public Guid Token { get; private set; }

        /// <summary>
        /// Date and time the token will expire
        /// </summary>
        public DateTime ExpireOn { get; private set; }

        /// <summary>
        /// URL of the credential creation/reset page
        /// </summary>
        public string UrlCredential { get; private set; }

        #endregion

    }
}
