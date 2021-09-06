using RSoft.Lib.Common.ValueObjects;
using System;

namespace RSoft.Lib.Common.Contracts.Entities
{

    /// <summary>
    /// Created author interface
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface ICreatedAuthor<TKey>
        where TKey : struct
    {

        /// <summary>
        /// Row create date
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Created author data
        /// </summary>
        Author<TKey> CreatedAuthor { get; set; }

    }
}