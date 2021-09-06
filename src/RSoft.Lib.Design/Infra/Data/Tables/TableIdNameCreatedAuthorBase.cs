namespace RSoft.Lib.Design.Infra.Data.Tables
{

    /// <summary>
    /// Abstract table entity class with id and description column
    /// </summary>
    /// <typeparam name="TKey">Table entity key type</typeparam>
    /// <typeparam name="TTable">Table entity type</typeparam>
    public abstract class TableIdNameCreatedAuthorBase<TKey, TTable> : TableIdCreatedAuthorBase<TKey, TTable>
        where TKey : struct
        where TTable : TableIdCreatedAuthorBase<TKey, TTable>
    {

        #region Constructors

        /// <summary>
        /// Create a new table entity instance
        /// </summary>
        public TableIdNameCreatedAuthorBase() : base() { }

        /// <summary>
        /// Create a new table entity instance
        /// </summary>
        /// <param name="id">Id value</param>
        /// <param name="name">Name value</param>
        public TableIdNameCreatedAuthorBase(TKey id, string name) : base(id)
        {
            Name = name;
        }

        #region Properties

        /// <summary>
        /// Table name value
        /// </summary>
        public string Name { get; set; }

        #endregion



        #endregion

    }

}
