using RSoft.Lib.Common.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RSoft.Lib.Design.Application.Commands
{

    /// <summary>
    /// Command result base contract
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CommandResult<TResponse>
    {

        /// <summary>
        /// Success status operation flag
        /// </summary>
        public bool Success { get { return Errors.Count() == 0; } }

        /// <summary>
        /// Error status flag
        /// </summary>
        public bool HasError { get { return Errors.Count() > 0; } }

        /// <summary>
        /// Response data object
        /// </summary>
        public TResponse Response { get; set; }

        /// <summary>
        /// Errors dictionary
        /// </summary>
        public IList<GenericNotification> Errors { get; set; } = new List<GenericNotification>();

    }

}
