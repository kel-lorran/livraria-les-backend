using Shared;

namespace Domain.Shared.Entities
{
    public class Address : Identity<Address, int>
    {
        public Address() 
        {
        }

        public Address(Address address) 
        {
            this.HomeType = address.HomeType;
            this.PublicPlaceType = address.PublicPlaceType;
            this.PublicPlaceName = address.PublicPlaceName;
            this.HomeNumber = address.HomeNumber;
            this.CEP = address.CEP;
            this.Neighborhood = address.Neighborhood;
            this.City = address.City;
            this.State = address.State;
            this.Country = address.Country;
            this.Complement = address.Complement;
            this.AddressLabel = address.AddressLabel; 
        }

        public Address(string homeType, string publicPlaceType, string publicPlaceName, string homeNumber, string cEP, string neighborhood, string city, string state, string country, string complement, string addressLabel) 
        {
            this.HomeType = homeType;
            this.PublicPlaceType = publicPlaceType;
            this.PublicPlaceName = publicPlaceName;
            this.HomeNumber = homeNumber;
            this.CEP = cEP;
            this.Neighborhood = neighborhood;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Complement = complement;
            this.AddressLabel = addressLabel;   
        }

        public int Id { get => base.Id; set => base.Id = value; }
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
    }
}