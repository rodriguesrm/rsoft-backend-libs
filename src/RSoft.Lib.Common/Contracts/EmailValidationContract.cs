using RSoft.Lib.Common.Abstractions;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// E-mail validation contract. Validate if e-mail is valid.
    /// </summary>
    public class EmailValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Craate a new instance of contract
        /// </summary>
        /// <param name="email">E-mail to validate</param>
        public EmailValidationContract(string email) : this(email, true) { }

        /// <summary>
        /// Craate a new instance of contract
        /// </summary>
        /// <param name="email">E-mail to validate</param>
        /// <param name="required">Indicates whether email is required (default true)</param>
        public EmailValidationContract(string email, bool required) : base()
        {
            if (required)
                Contract.Requires();
            Contract
                .IsEmailOrEmpty(email, "Email", ServiceActivator.GetStringInLocalizer<EmailValidationContract>("EMAIL_INVALID", "Invalid e-mail"));
        }

        #endregion

    }
}
