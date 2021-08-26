using RSoft.Lib.Common.Abstractions;
using RSoft.Lib.Common.Contracts.Entities;

namespace RSoft.Lib.Common.Contracts
{

    /// <summary>
    /// Address validate contract, where:
    /// Street name is required and has 2 and 80 characters.
    /// Address number is required and has 20 maximum characters.
    /// Secondary address is optional, but has 40 maxium characters.
    /// District/Neighborhood is required and 2 and 50 characters.
    /// City is required and 2 and 80 characters.
    /// State is required and has 2 characters.
    /// Zip code is required and has 8 digits (only numbers)
    /// </summary>
    public class AddressValidationContract : BaseValidationContract
    {

        #region Constructors

        /// <summary>
        /// Create a new instance of object
        /// </summary>
        /// <param name="address">Address object instance</param>
        public AddressValidationContract(IAddress address)
        {

            Contract
                .Requires()

                .IsNotNullOrEmpty(address.StreetName, "StreetName", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("STREET_NAME_REQUIRED", "Street name is required"))
                .HasMinLen(address.StreetName ?? string.Empty, 2, "StreetName", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("STREET_NAME_MIN_SIZE", "Street name must contain at least 2 characters"))
                .HasMaxLen(address.StreetName ?? string.Empty, 80, "StreetName", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("STREET_NAME_MAX_SIZE", "Street name must contain a maximum of 80 characters"))

                .IsNotNullOrEmpty(address.AddressNumber, "AddressNumber", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("ADDRESS_NUMBER_REQUIRED", "Address number is required"))
                .HasMaxLen(address.StreetName ?? string.Empty, 20, "AddressNumber", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("ADDRESS_NUMBER_MAX_SIZE", "Address number must contain a maximum of 20 characters"))

                .HasMaxLen(address.SecondaryAddress ?? string.Empty, 40, "SecondaryAddress", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("SECONDARY_ADDRESS_MAX_SIZE", "Secondary address must contain a maximum of 40 characters"))

                .IsNotNullOrEmpty(address.District, "District", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("NEIGHBORHOOD_REQUIRED", "District/Neighborhood is required"))
                .HasMinLen(address.District ?? string.Empty, 2, "District", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("NEIGHBORHOOD_MIN_SIZE", "District/Neighborhood must contain at least 2 characters"))
                .HasMaxLen(address.District ?? string.Empty, 50, "District", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("NEIGHBORHOOD_MAX_SIZE", "District/Neighborhood must contain a maximum of 50 characters"))

                .IsNotNullOrEmpty(address.City, "City", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("CITY_REQUIRED", "City is required"))
                .HasMinLen(address.City ?? string.Empty, 2, "City", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("CITY_MIN_SIZE", "City must contain at least 2 characters"))
                .HasMaxLen(address.City ?? string.Empty, 80, "City", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("CITY_MAX_SIZE", "City must contain a maximum of 80 characters"))

                .IsNotNullOrEmpty(address.State, "State", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("STATE_REQUIRED", "State is required"))
                .HasLen(address.State ?? string.Empty, 2, "State", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("STATE_SIZE", "State must contain exactly 2 positions"))

                .IsNotNullOrEmpty(address.ZipCode, "ZipCode", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("ZIP_CODE_REQUIRED", "Zip code is required"))
                .HasLen(address.ZipCode, 8, "ZipCode", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("ZIP_COD_SIZE", "The zip code must contain exactly 8 positions"))
                .Matchs(address.ZipCode, "[0-9]{8}", "ZipCode", ServiceActivator.GetStringInLocalizer<AddressValidationContract>("ZIP_CODE_ONLY_NUMBERS", "Zip code is in an invalid format (enter numbers only)"));

        }

        #endregion

    }
}
