using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Contracts.Dtos
{

    /// <summary>
    /// Created author Dto interface
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface ICreatedAuthorDto<TKey>
        where TKey : struct
    {

        /// <summary>
        /// Created author data
        /// </summary>
        AuditAuthor<TKey> CreatedBy { get; set; }

    }

}
