using System.Collections.Generic;
using System.Text.Json;

namespace RSoft.Lib.Common.Models
{

    /// <summary>
    /// Generic notification response model
    /// </summary>
    public class GenericNotification
    {

        #region Constructors

        /// <summary>
        /// Create a new GenericNotificationResponse instance
        /// </summary>
        /// <param name="property">Property/Field name</param>
        /// <param name="message">Message detail</param>
        public GenericNotification(string property, string message)
        {
            Property = property;
            Message = message;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property/Field name
        /// </summary>
        /// <example>Name</example>
        public string Property { get; set; }

        /// <summary>
        /// Message detail
        /// </summary>
        /// <example>The name field is required</example>
        public string Message { get; set; }

        #endregion

    }

}
