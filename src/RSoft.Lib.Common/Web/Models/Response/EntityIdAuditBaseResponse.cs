using RSoft.Lib.Common.Contracts.Dtos;
using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Web.Models.Response
{

    /// <summary>
    /// Abstract base model-reponse with audit-authors and id
    /// </summary>
    public abstract class EntityIdAuditBaseResponse<TKey> : EntityIdBaseResponse<TKey>, IAuditDto<TKey>
        where TKey : struct
    {

        #region Constructors

        /// <summary>
        /// Create a new object instance
        /// </summary>
        /// <param name="id">Key value</param>
        /// <param name="createdBy">Create author</param>
        /// <param name="changedBy">Change author</param>
        public EntityIdAuditBaseResponse(TKey id, AuditAuthor<TKey> createdBy, AuditAuthor<TKey> changedBy) : base(id)
        {
            CreatedBy = createdBy;
            ChangedBy = changedBy;
        }

        #endregion

        #region Propriedades

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
