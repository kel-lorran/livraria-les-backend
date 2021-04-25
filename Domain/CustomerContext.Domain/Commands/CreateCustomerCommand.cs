using Shared;

namespace Domain.CustomerContext
{
    public class CreateCustomerCommand : ICommand
    {
        public CreateCustomerCommand() 
        {      
        }

        public CreateCustomerCommand(string name, string lastName, string gender, string cPF, string birthDate, string phone, string email, string password, string homeType, string publicPlaceType, string publicPlaceName, string homeNumber, string cEP, string neighborhood, string city, string state, string country, string complement, string addressLabel) 
        {
            this.Name = name;
            this.LastName = lastName;
            this.Gender = gender;
            this.CPF = cPF;
            this.BirthDate = birthDate;
            this.Phone = phone;
            this.Email = email;

            this.Password = password;
            
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

        public int UserId { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Active { get => 1; }

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

        public void SetUserId(int id)
        {
            UserId = id;
        }
    }
}