using RSoft.Lib.Common.Contracts.Dtos;
using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Web.Models.Response
{

    /// <summary>
    /// Abstract audit-response base object
    /// </summary>
    public abstract class EntityAuditBaseResponse<TKey> : EntityBaseResponse, IAuditDto<TKey>
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
