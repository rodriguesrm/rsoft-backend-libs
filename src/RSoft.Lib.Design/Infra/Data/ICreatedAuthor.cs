using System;

namespace RSoft.Lib.Design.Infra.Data
{

    /// <summary>
    /// Created author interface
    /// </summary>
    /// <typeparam name="TKey">Refence author creation/changed key type</typeparam>
    public interface ICreatedAuthor<TKey>
        where TKey : struct
    {

        #region Properties

        /// <summary>
        /// Row's create date
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// User's id created row
        /// </summary>
        TKey CreatedBy { get; set; }

        #endregion

    }

}
