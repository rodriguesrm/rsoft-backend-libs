namespace RSoft.Lib.Common.Web.Models.Request
{

    /// <summary>
    /// E-mail address request model
    /// </summary>
    public class EmailAddressRequest
    {

        #region Constructors

        /// <summary>
        /// Initialize a new instance of EmailAddressRequest
        /// </summary>
        /// <param name="email">Sender/Recipient e-mail address</param>
        public EmailAddressRequest(string email) : this(email, null) { }

        /// <summary>
        /// Initialize a new instance of EmailAddressRequest
        /// </summary>
        /// <param name="email">Sender/Recipient e-mail address</param>
        /// <param name="name">Sender/Recipient name</param>
        public EmailAddressRequest(string email, string name)
        {
            Email = email;
            Name = name;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sender/Recipient e-mail address
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Sender/Recipient name
        /// </summary>
        public string Name { get; private set; }

        #endregion

    }
}
