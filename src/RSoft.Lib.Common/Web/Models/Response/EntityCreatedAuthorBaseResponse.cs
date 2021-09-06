using RSoft.Lib.Common.Contracts.Dtos;
using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Web.Models.Response
{

    /// <summary>
    /// Abstract audit-response base object
    /// </summary>
    public abstract class EntityCreatedAuthorBaseResponse<TKey> : EntityBaseResponse, ICreatedAuthorDto<TKey>
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
