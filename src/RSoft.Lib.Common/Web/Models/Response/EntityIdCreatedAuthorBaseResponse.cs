using RSoft.Lib.Common.Contracts.Dtos;
using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Web.Models.Response
{

    /// <summary>
    /// Abstract base model-reponse with audit-authors and id
    /// </summary>
    public abstract class EntityIdCreatedAuthorBaseResponse<TKey> : EntityIdBaseResponse<TKey>, ICreatedAuthorDto<TKey>
        where TKey : struct
    {

        #region Constructors

        /// <summary>
        /// Create a new object instance
        /// </summary>
        /// <param name="id">Key value</param>
        /// <param name="createdBy">Create author</param>
        public EntityIdCreatedAuthorBaseResponse(TKey id, AuditAuthor<TKey> createdBy) : base(id)
        {
            CreatedBy = createdBy;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Created author data
        /// </summary>
        public AuditAuthor<TKey> CreatedBy { get; set; }


        #endregion

    }

}
