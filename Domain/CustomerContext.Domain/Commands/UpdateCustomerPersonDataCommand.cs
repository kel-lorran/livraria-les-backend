using System;
using Shared;
using Shared.Utils;

namespace Domain.CustomerContext
{
    public class UpdateCustomerPersonDataCommand : ICommandWithValidation
    {
        public UpdateCustomerPersonDataCommand()
        {
        }

        public UpdateCustomerPersonDataCommand(string name, string lastName, string gender, string cPF, string birthDate, string phone, string email, int active)
        {
            Name = name;
            LastName = lastName;
            Gender = gender;
            CPF = cPF;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Active = active;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Active { get; set; }

        public Customer Entity { get; private set; }

        public Customer MergeEntity(Customer customer)
        {
            // foreach (var prop in this.GetType().GetProperties())
            // {
            //     var value = this.GetType().GetProperty(prop.Name).GetValue(this);
            //     if(value != null && prop.CanWrite)
            //     {
            //         prop.SetValue(customer, Convert.ChangeType(value, prop.PropertyType));
            //     }
            // }
            if (Name != null && !customer.Name.Equals(Name))
                customer.Name = Name;
            if (LastName != null && !customer.LastName.Equals(LastName))
                customer.LastName = LastName;
            if (Gender != null && !customer.Gender.Equals(Gender))
                customer.Gender = Gender;
            if (CPF != null && !customer.CPF.Equals(CPF))
                customer.CPF = CPF;
            if (BirthDate != null)
                customer.BirthDate = StringToDateTime.Convert(BirthDate, "yyyy-MM-dd");
            if (Phone != null && !customer.Phone.Equals(Phone))
                customer.Phone = Phone;
            
            Entity = customer;
            return customer;
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
            
            return new GenericCommandResult(result, message);
        }
    }
}