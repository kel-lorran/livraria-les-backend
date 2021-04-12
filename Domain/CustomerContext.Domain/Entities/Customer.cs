using System.Collections.Generic;
using Shared;

namespace Domain.CustomerContext
{
    public class Customer : Identity<Customer, int>
    {
        public Customer() 
        {      
        }

        public Customer(string name, string lastName, string gender, string cPF, string birthDate, string phone, string email, int active, List<Address> addressList) 
        {
            this.Name = name;
            this.LastName = lastName;
            this.Gender = gender;
            this.CPF = cPF;
            this.BirthDate = birthDate;
            this.Phone = phone;
            this.Email = email;
            this.Active = active;
            this.AddressList = addressList;   
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Active { get; set; }
        public List<Address> AddressList { get; set; }
    }
}