using System;

namespace RSoft.Lib.Common.Options
{

    /// <summary>
    /// Application-Client options model configuration
    /// </summary>
    public class AppClientOptions
    {

        /// <summary>
        /// Application-Client id
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Application-Client secret
        /// </summary>
        public Guid ClientSecret { get; set; }

    }
}
