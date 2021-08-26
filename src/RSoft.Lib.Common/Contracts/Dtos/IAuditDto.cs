using RSoft.Lib.Common.Models;

namespace RSoft.Lib.Common.Contracts.Dtos
{

    /// <summary>
    /// Audit Dto interface
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IAuditDto<TKey>
        where TKey : struct
    {

        /// <summary>
        /// Created author data
        /// </summary>
        AuditAuthor<TKey> CreatedBy { get; set; }

        /// <summary>
        /// Changed author data
        /// </summary>
        AuditAuthor<TKey> ChangedBy { get; set; }

    }

}
