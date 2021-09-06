using RSoft.Lib.Common.Contracts.Entities;
using RSoft.Lib.Common.ValueObjects;
using System;

namespace RSoft.Lib.Design.Domain.Entities
{

    /// <summary>
    /// Abstract entity class with id column
    /// </summary>
    /// <typeparam name="TKey">Entity key type</typeparam>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class EntityIdCreatedAuthorBase<TKey, TEntity> : EntityIdBase<TKey, TEntity>, ICreatedAuthor<TKey>
        where TKey : struct
        where TEntity : EntityIdCreatedAuthorBase<TKey, TEntity>
    {

        #region Constructors

        /// <summary>
        /// Create a new entity instance
        /// </summary>
        public EntityIdCreatedAuthorBase() : base() { }

        /// <summary>
        /// Create a new entity instance
        /// </summary>
        /// <param name="id">Entity id</param>
        public EntityIdCreatedAuthorBase(TKey id) : base(id) { }

        #endregion

        #region Properties

        ///<inheritdoc/>
        public DateTime CreatedOn { get; set; }

        ///<inheritdoc/>
        public Author<TKey> CreatedAuthor { get; set; }

        #endregion

    }

}