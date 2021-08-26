using System.ComponentModel;

namespace RSoft.Lib.Common.Enums
{

    /// <summary>
    /// User type
    /// </summary>
    public enum UserType
    {

        /// <summary>
        /// A human user
        /// </summary>
        [Description("A human user")]
        User = 1,

        /// <summary>
        /// An application or service
        /// </summary>
        [Description("An application or service")]
        Service = 2

    }
}
