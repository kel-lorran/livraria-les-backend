using System;
using System.Collections.Generic;
using Domain.Shared.Entities;
using Shared;

namespace Domain.CustomerContext
{
    public class Customer : Entity
    {
        private List<CreditCard> _creditCardList = new List<CreditCard>();
        public Customer() 
        {      
        }

        public Customer(int userId, string name, string lastName, string gender, string cPF, DateTime birthDate, string phone, string email, int active, List<Address> addressList) 
        {
            this.UserId = userId;
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

        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Active { get; set; }
        public List<Address> AddressList { get; set; }
        public List<CreditCard> CreditCardList { get => _creditCardList; set => _creditCardList = value; }
    }
}