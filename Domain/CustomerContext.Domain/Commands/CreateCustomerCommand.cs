using System;
using Shared;
using Shared.Utils;

namespace Domain.CustomerContext
{
    public class CreateCustomerCommand : ICommandWithValidation
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

        public GenericCommandResult Validate()
        {
            var result = true;
            var message = "";

            if (!TextValidator.Validity(Name)) {
                result = false;
                message += "Name is required\n";
            }
            if (!TextValidator.Validity(LastName)) {
                result = false;
                message += "LastName is required\n";
            }
            if (!TextValidator.Validity(Gender, @"^[f|m|u]$")) {
                result = false;
                message += "Gender is required, allow values f|m|u\n";
            }
            if (!TextValidator.Validity(CPF, @"(\d{11})|(\d{3}\.\d{3}\.\d{3}-\d{2})")) {
                result = false;
                message += "CPF is required, allow \\d{11} or 000.000.000-00 \n";
            }
            if (!TextValidator.Validity(BirthDate, @"\d{4}-\d{2}-\d{2}")) {
                if (StringToDateTime.Convert(BirthDate, "yyyy-MM-dd") > DateTime.Now.AddYears(-4)) {
                    result = false;
                    message += "BirthDate is invalid, allow \n";
                }
            }
            if (!TextValidator.Validity(Phone, @"(\d{10,11})|(\(\d{2}\)\s\d{4,5}-\d{4})", @"\D")) {
                result = false;
                message += "Phone is required, allow \\d{11} or (00) 90000-0000\n";
            }
            if (!TextValidator.Validity(Email, @".+@.{1,}\..{1,}")) {
                result = false;
                message += "Email is required\n";
            }
            if (!TextValidator.Validity(Password, @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{8,}")) {
                result = false;
                message += "Password is required, allow one uppercase letter, one lowercase letter and one special character, and have more than 8 characters\n";
            }
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