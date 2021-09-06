using System;

namespace RSoft.Lib.Design.Infra.Data.Tables
{

    /// <summary>
    /// Table entity abstract class with id column
    /// </summary>
    /// <typeparam name="TTable">Table entity type</typeparam>
    /// <typeparam name="TKey">Table entity key</typeparam>
    public abstract class TableCreatedAuthorBase<TTable, TKey> : TableBase<TTable>, ITable, ICreatedAuthor<TKey>
        where TTable : TableBase<TTable>
        where TKey : struct
    {

        #region Constructors

        /// <summary>
        /// Create a new table instance
        /// </summary>
        public TableCreatedAuthorBase() : base() { }

        #endregion

        #region Properties

        /// <summary>
        /// Log creation date
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Log creation user id
        /// </summary>
        TKey ICreatedAuthor<TKey>.CreatedBy { get; set; }



        #endregion

    }

}
