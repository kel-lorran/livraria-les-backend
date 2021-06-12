using System;
using Shared;
using Shared.Utils;

namespace Domain.CustomerContext
{
    public class UpdateCustomerPersonDataCommand : ICommand
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
            
            return customer;
        }
    }
}