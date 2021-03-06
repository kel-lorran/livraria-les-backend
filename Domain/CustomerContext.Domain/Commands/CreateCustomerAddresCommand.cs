using Shared;
using Shared.Utils;

namespace Domain.CustomerContext
{
    public class CreateCustomerAddresCommand : ICommandWithValidation
    {
        public CreateCustomerAddresCommand() 
        {      
        }

        public CreateCustomerAddresCommand(string homeType, string publicPlaceType, string publicPlaceName, string homeNumber, string cEP, string neighborhood, string city, string state, string country, string complement, string addressLabel, int customerId)
        {
            HomeType = homeType;
            PublicPlaceType = publicPlaceType;
            PublicPlaceName = publicPlaceName;
            HomeNumber = homeNumber;
            CEP = cEP;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            Complement = complement;
            AddressLabel = addressLabel;
            CustomerId = customerId;
        }

        public string HomeType { get; set; }
        public string PublicPlaceType { get; set; }
        public string PublicPlaceName { get; set; }
        public string HomeNumber { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Complement { get; set; }
        public string AddressLabel { get; set; }
        public int CustomerId { get; set; }

        public GenericCommandResult Validate()
        {
            var result = true;
            var message = "";

            if (!TextValidator.Validity(HomeType)) {
                result = false;
                message += "HomeType is required\n";
            }
            if (!TextValidator.Validity(PublicPlaceType)) {
                result = false;
                message += "PublicPlaceType is required\n";
            }
            if (!TextValidator.Validity(PublicPlaceName)) {
                result = false;
                message += "PublicPlaceName is required\n";
            }
            if (!TextValidator.Validity(HomeNumber, @"(?=.*\d).{1,}")) {
                result = false;
                message += "HomeNumber is required\n";
            }
            if (!TextValidator.Validity(CEP, @"(\d{8})|(\d{5}-\d{3})", @"\D")) {
                result = false;
                message += "CEP is required, allow \\d{8} or 00000-000 \n";
            }
            if (!TextValidator.Validity(Neighborhood)) {
                result = false;
                message += "Neighborhood is required\n";
            }
            if (!TextValidator.Validity(City)) {
                result = false;
                message += "City is required\n";
            }
            if (!TextValidator.Validity(State)) {
                result = false;
                message += "State is required\n";
            }
            if (!TextValidator.Validity(Country)) {
                result = false;
                message += "Country is required\n";
            }
            if (!TextValidator.Validity(AddressLabel)) {
                result = false;
                message += "AddressLabel is required\n";
            }
            
            return new GenericCommandResult(result, message);
        }
    }
}