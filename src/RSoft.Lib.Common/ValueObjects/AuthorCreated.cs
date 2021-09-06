using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Common.Resources;
using System;

namespace RSoft.Lib.Common.ValueObjects
{

    /// <summary>
    /// Audit value object model
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    public class AuthorCreated<TKey> : BaseVO, ICreatedAuthor<TKey>
        where TKey : struct
    {


        #region Constructors

        /// <summary>
        /// Create a new Audit-Value-Object instance
        /// </summary>
        /// <param name="createdOn">Row created date</param>
        /// <param name="createdAuthor">Created author data</param>
        public AuthorCreated(DateTime createdOn, Author<TKey> createdAuthor)
        {
            CreatedOn = createdOn;
            CreatedAuthor = createdAuthor;
            Validate();
        }

        #endregion

        #region Properties

        ///<inheritdoc/>
        public DateTime CreatedOn { get; set; }

        ///<inheritdoc/>
        public Author<TKey> CreatedAuthor { get; set; }

        #endregion

        #region Overrides

        ///<inheritdoc/>
        protected override void Validate()
        {
            if (CreatedAuthor == null)
                AddNotification(nameof(CreatedAuthor), ServiceActivator.GetStringInLocalizer<SharedLanguageResource>("CREATED_AUTHOR_REQUIRED", "{0} is required", nameof(CreatedAuthor)));
            if (CreatedAuthor != null) AddNotifications(CreatedAuthor.Notifications);
        }

        #endregion

    }
}