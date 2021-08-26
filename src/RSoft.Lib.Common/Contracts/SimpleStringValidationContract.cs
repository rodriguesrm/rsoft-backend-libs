using RSoft.Lib.Common.Abstractions;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// String validaction contract
    /// </summary>
    public class SimpleStringValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="expression">Expression to validate</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="required">Indicate if field is required</param>
        public SimpleStringValidationContract(string expression, string fieldName, bool required) : this(expression, fieldName, required, null, null, null) { }

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="expression">Expression to validate</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="required">Indicate if field is required</param>
        /// <param name="pattern">Acceptance pattern regular expression</param>
        public SimpleStringValidationContract(string expression, string fieldName, bool required, string pattern) : this(expression, fieldName, required, pattern, null, null) { }

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="expression">Expression to validate</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="required">Indicate if field is required</param>
        /// <param name="minLen">Indicate a mininum length expression</param>
        /// <param name="maxLen">Indicate a maximum length expression</param>
        public SimpleStringValidationContract(string expression, string fieldName, bool required, int? minLen, int? maxLen) : this(expression, fieldName, required, null, minLen, maxLen) { }

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="expression">Expression to validate</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="required">Indicate if field is required</param>
        /// <param name="pattern">Acceptance pattern regular expression</param>
        /// <param name="minLen">Indicate a mininum length expression</param>
        /// <param name="maxLen">Indicate a maximum length expression</param>
        public SimpleStringValidationContract(string expression, string fieldName, bool required, string pattern, int? minLen, int? maxLen)
        {

            if (expression != null)
                expression = expression.Trim();

            if (required)
                Contract
                    .Requires()
                    .IsNotNullOrEmpty(expression, fieldName, ServiceActivator.GetStringInLocalizer<SimpleStringValidationContract>("FIELD_REQUIRED", "The {0} field is required", fieldName));

            if (expression != null)
            {

                if (!string.IsNullOrWhiteSpace(pattern))
                    Contract.Matchs(expression, pattern, fieldName, ServiceActivator.GetStringInLocalizer<SimpleStringValidationContract>("FIELD_INVALID", "{0} is invalid", fieldName));

                if ((minLen ?? 0) > 0 && (maxLen ?? 0) > 0 && minLen.Value == maxLen.Value)
                {
                    Contract.HasLen(expression, minLen.Value, fieldName, ServiceActivator.GetStringInLocalizer<SimpleStringValidationContract>("FIELD_MIN_SIZE", "The {0} must have {1} character(s)", fieldName, minLen.Value));
                }
                else
                {

                    if (minLen.HasValue && minLen.Value > 0)
                        Contract
                            .HasMinLen(expression, minLen.Value, fieldName, ServiceActivator.GetStringInLocalizer<SimpleStringValidationContract>("FIELD_MIN_SIZE", "The {0} field must contain at least {1} character(s)", fieldName, minLen.Value));

                    if (maxLen.HasValue && maxLen.Value > 0 && maxLen.Value >= (minLen ?? 0))
                        Contract
                            .HasMaxLen(expression, maxLen.Value, fieldName, ServiceActivator.GetStringInLocalizer<SimpleStringValidationContract>("FIELD_MAX_SIZE", "The {0} fields must contain a maximum {1} character(s)", fieldName, maxLen.Value));

                }

            }

        }

        #endregion

    }
}
