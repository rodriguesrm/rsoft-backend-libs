using System;

namespace RSoft.Lib.Design.Infra.Data.Tables
{

    /// <summary>
    /// Abstract table entity class with id column
    /// </summary>
    /// <typeparam name="TKey">Table entity key type</typeparam>
    /// <typeparam name="TTable">Table entity type</typeparam>
    public abstract class TableIdCreatedAuthorBase<TKey, TTable> : TableIdBase<TKey, TTable>, ICreatedAuthor<TKey>
        where TKey : struct
        where TTable : TableIdCreatedAuthorBase<TKey, TTable>
    {

        #region Constructors

        /// <summary>
        /// Create a new table entity instance
        /// </summary>
        public TableIdCreatedAuthorBase() : base() { }

        /// <summary>
        /// Create a new table entity instance
        /// </summary>
        /// <param name="id">Entity id</param>
        public TableIdCreatedAuthorBase(TKey id) : base(id) { }

        #endregion

        #region Properties

        /// <summary>
        /// Log creation date
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Log creation user id
        /// </summary>
        public TKey CreatedBy { get; set; }

        #endregion

    }

}
