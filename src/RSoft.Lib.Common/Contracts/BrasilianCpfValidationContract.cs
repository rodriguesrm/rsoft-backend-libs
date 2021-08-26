using RSoft.Lib.Common.Abstractions;
using hlp = RSoft.Helpers.Validations.BrasilianDocument;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// Brasilian document cpf validation contract
    /// </summary>
    public class BrasilianCpfValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="cpf">Cpf number (withou mask)</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="required">Indicates whether the CPF is mandatory</param>
        public BrasilianCpfValidationContract(string cpf, string fieldName, bool required)
        {

            if (required)
                if (string.IsNullOrWhiteSpace(cpf))
                    Contract.AddNotification(fieldName, ServiceActivator.GetStringInLocalizer<BrasilianCpfValidationContract>("DOCUMENT_REQUIRED", "CPF is required"));

            if (!string.IsNullOrWhiteSpace(cpf))
                Contract
                    .IsTrue(hlp.CheckDocument(cpf), fieldName, ServiceActivator.GetStringInLocalizer<BrasilianCpfValidationContract>("DOCUMENT_INVALID", "CPF invalid"));
        }

        #endregion

    }
}
