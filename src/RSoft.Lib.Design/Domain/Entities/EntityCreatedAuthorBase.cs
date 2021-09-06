using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Common.ValueObjects;
using System;

namespace RSoft.Lib.Design.Domain.Entities
{

    /// <summary>
    /// Entity abstract class
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TKey">Entity key type</typeparam>
    public abstract class EntityCreatedAuthorBase<TEntity, TKey> : EntityBase<TEntity>, IEntity, ICreatedAuthor<TKey>
        where TEntity : EntityBase<TEntity>
        where TKey : struct
    {

        #region Constructors

        /// <summary>
        /// Create a new entity instance
        /// </summary>
        public EntityCreatedAuthorBase() : base() { }

        #endregion

        #region Properties

        ///<inheritdoc/>
        public DateTime CreatedOn { get; set; }

        ///<inheritdoc/>
        public Author<TKey> CreatedAuthor { get; set; }

        #endregion

    }

}