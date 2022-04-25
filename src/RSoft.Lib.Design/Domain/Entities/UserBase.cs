using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Common.ValueObjects;
using System;

namespace RSoft.Lib.Design.Domain.Entities
{

    /// <summary>
    /// User entity base
    /// </summary>
    /// <typeparam name="TUser">User entity object</typeparam>
    public abstract class UserBase<TUser> : EntityIdBase<Guid, TUser>, IActive
        where TUser : UserBase<TUser>
    {

        #region Constructors

        /// <summary>
        /// Create a new user instance
        /// </summary>
        public UserBase() : base(Guid.NewGuid()) { }

        /// <summary>
        /// Create a new user instance
        /// </summary>
        /// <param name="id">Category id value</param>
        public UserBase(Guid id) : base(id) { }

        /// <summary>
        /// Create a new user instance
        /// </summary>
        /// <param name="id">Category id text</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public UserBase(string id) : base()
        {
            Id = new Guid(id);
        }

        #endregion

        #region Properties

        /// <summary>
        /// User full name
        /// </summary>
        public Name Name { get; set; } = new Name(string.Empty, string.Empty);

        /// <summary>
        /// Indicate if entity is active
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Validate entity
        /// </summary>
        public override void Validate()
        {
            AddNotifications(Name.Notifications);
        }

        #endregion

    }
}
