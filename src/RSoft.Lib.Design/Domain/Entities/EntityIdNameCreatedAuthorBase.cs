namespace RSoft.Lib.Design.Domain.Entities
{

    /// <summary>
    /// Abstract entity class with id and description column
    /// </summary>
    /// <typeparam name="TKey">Entity key type</typeparam>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class EntityIdNameCreatedAuthorBase<TKey, TEntity> : EntityIdCreatedAuthorBase<TKey, TEntity>
        where TKey : struct
        where TEntity : EntityIdCreatedAuthorBase<TKey, TEntity>
    {

        #region Constructors

        /// <summary>
        /// Create a new entity instance
        /// </summary>
        public EntityIdNameCreatedAuthorBase() : base() { }

        /// <summary>
        /// Create a new entity instance
        /// </summary>
        /// <param name="id">Id value</param>
        /// <param name="name">Name value</param>
        public EntityIdNameCreatedAuthorBase(TKey id, string name) : base(id)
        {
            Name = name;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Entity name value
        /// </summary>
        public string Name { get; set; }

        #endregion

    }

}
