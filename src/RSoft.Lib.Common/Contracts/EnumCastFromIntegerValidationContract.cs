using RSoft.Lib.Common.Abstractions;
using System;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// Enum validation contract
    /// </summary>
    public class EnumCastFromIntegerValidationContract<TEnum> : BaseValidationContract
        where TEnum : struct //, IConvertible
    {

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="number">Number value to validate</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="required">Required status flag</param>
        public EnumCastFromIntegerValidationContract(int? number, string fieldName, bool required)
        {

            string requiredMessage = ServiceActivator.GetStringInLocalizer<EnumCastFromIntegerValidationContract<TEnum>>("FIELD_REQUIRED", "The {0} field is required", fieldName);
            string invalidMessage = ServiceActivator.GetStringInLocalizer<EnumCastFromIntegerValidationContract<TEnum>>("INVALID_MESSAGE", "The value entered for field {0} is invalid", fieldName);

            if (required)
                Contract
                    .Requires()
                    .IsNotNull(number, fieldName, requiredMessage);

            if (number.HasValue)
            {

                Enum.TryParse(number.Value.ToString(), out TEnum result);
                if (!Enum.IsDefined(typeof(TEnum), result))
                    Contract.
                        AddNotification(fieldName, invalidMessage);
            }

        }

    }
}
