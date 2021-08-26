using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Dtos
{

    /// <summary>
    /// Abstract dto-audit-data model base object
    /// </summary>
    public abstract class AppDtoAuditBase<TKey> : AppDtoBase
        where TKey : struct
    {

        #region Properties

        /// <summary>
        /// Created author data
        /// </summary>
        public AuditAuthor<TKey> CreatedBy { get; set; }

        /// <summary>
        /// Changed author data
        /// </summary>
        public AuditAuthor<TKey> ChangedBy { get; set; }

        #endregion

    }

}