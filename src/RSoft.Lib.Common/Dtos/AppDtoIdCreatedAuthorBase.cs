using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Dtos
{

    /// <summary>
    /// Abstract dto-id-audit model base object
    /// </summary>
    public abstract class AppDtoIdCreatedAuthorBase<TKey> : AppDtoIdBase<TKey>
        where TKey : struct
    {

        #region Properties

        /// <summary>
        /// Created author data
        /// </summary>
        public AuditAuthor<TKey> CreatedBy { get; set; }

        #endregion

    }

}
