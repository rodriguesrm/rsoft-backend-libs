using RSoft.Lib.Common.Abstractions;
using System;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// Contract future date validation. Validate date if is in future.
    /// </summary>
    public class FutureDateValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Create a new instance of contract
        /// </summary>
        /// <param name="date">Date to validate</param>
        /// <param name="field">Field name</param>
        /// <param name="message">Critical message</param>
        public FutureDateValidationContract(DateTime? date, string field, string message) : base()
        {

            Contract
                .IsNotNull(date, field, message)
                .IsGreaterOrEqualsThan(date.Value, DateTime.UtcNow, field, ServiceActivator.GetStringInLocalizer<FutureDateValidationContract>("INVALID_DATE", "The '{0}' must be greater than the current date", field))
            ;

        }

        #endregion

    }
}
