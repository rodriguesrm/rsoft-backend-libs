using System;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// Date validation contract. Validate if date is not null and valid;
    /// </summary>
    public class DateValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Create a new instance of contract
        /// </summary>
        /// <param name="date">Date to validate</param>
        /// <param name="field">Field name</param>
        /// <param name="message">Critical message</param>
        public DateValidationContract(DateTime? date, string field, string message) : base()
        {

            Contract
                .IsNotNull(date, field, message)
            ;

        }

        #endregion

    }
}
