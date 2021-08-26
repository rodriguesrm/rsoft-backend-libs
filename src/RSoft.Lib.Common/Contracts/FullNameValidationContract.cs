using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts.Entities;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// Full name validation contract.
    /// </summary>
    public class FullNameValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="name">Name object instance</param>
        public FullNameValidationContract(IFullName name) : this(name, new FullNameValidationArgument()
        {
            CharListAllowed = string.Empty,
            FirstNameMinimumLength = 2,
            FirstNameMaximumLength = 50,
            LastNameMinimumLength = 2,
            LastNameMaximumLength = 100
        })
        { }

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="name">Name object instance</param>
        /// <param name="args">Full name validation arguments</param>
        public FullNameValidationContract(IFullName name, FullNameValidationArgument args)
        {

            // Regular expression for all characteres name (global)
            // ^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$

            if (string.IsNullOrWhiteSpace(name.FirstName))
            {
                Contract.IsNotNullOrEmpty(name.FirstName, "First name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("FIRST_NAME_REQUIRED", "First name is required"));
            }
            else
            {
                Contract
                    .HasMinLen(name.FirstName ?? string.Empty, args.FirstNameMinimumLength, "First name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("FIRST_NAME_MIN_SIZE", "First name must contain at least {0} characters", args.FirstNameMinimumLength))
                    .HasMaxLen(name.FirstName ?? string.Empty, args.FirstNameMaximumLength, "Last name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("FIRST_NAME_MAX_SIZE", "First name must contain a maximum of {0} characters", args.FirstNameMaximumLength))
                    .Matchs(name.FirstName, $"^[a-zA-Z{args.CharListAllowed} ,.'-]+$", "First name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("FIRST_NAME_INVALID_CHARS", "First name contains invalid characters"));
            }

            if (string.IsNullOrWhiteSpace(name.LastName))
            {
                Contract.IsNotNullOrEmpty(name.LastName, "Last name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("LAST_NAME_REQUIRED", "Last name is required"));
            }
            else
            {
                Contract
                    .HasMinLen(name.LastName ?? string.Empty, args.LastNameMinimumLength, "Last name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("LAST_NAME_MIN_SIZE", "Last name must contain at least {0} characters", args.LastNameMinimumLength))
                    .HasMaxLen(name.LastName ?? string.Empty, args.LastNameMaximumLength, "Last name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("LAST_NAME_MAX_SIZE", "Last name must contain a maximum of {0} characters", args.LastNameMaximumLength))
                    .Matchs(name.LastName, $"^[a-zA-Z{args.CharListAllowed} ,.'-]+$", "Last name", ServiceActivator.GetStringInLocalizer<FullNameValidationContract>("LAST_NAME_INVALID_CHARS", "Last name contains invalid characters"));

            }

        }

        #endregion

    }
}
