using Shared;

namespace Domain.CustomerContext
{
    public class CreateCustomerAddresCommand : ICommand
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
    }
}