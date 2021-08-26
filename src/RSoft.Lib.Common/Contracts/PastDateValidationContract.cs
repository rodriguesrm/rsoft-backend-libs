using RSoft.Lib.Common.Abstractions;
using System;

namespace RSoft.Lib.Common.Contracts
{


    /// <summary>
    /// Past date validate contract. Validate if date is in past.
    /// </summary>
    public class PastDateValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Create a new instance of contract
        /// </summary>
        /// <param name="date">Date to validate</param>
        /// <param name="field">Field name</param>
        /// <param name="message">Critical message</param>
        public PastDateValidationContract(DateTime? date, string field, string message) : base()
        {

            Contract
                .IsNotNull(date, field, message)
                .IsLowerOrEqualsThan(
                    date == null ? DateTime.UtcNow : date.Value,
                    DateTime.UtcNow,
                    field,
                    ServiceActivator.GetStringInLocalizer<PastDateValidationContract>("INVALID_DATE", "The '{0}' must be less than the current date", field))
            ;

        }

        #endregion

    }
}
