using System.Collections.Generic;
using System.Linq;
using Domain.CustomerContext;
using Microsoft.EntityFrameworkCore;
using Shared.Utils;

namespace Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _context.Entry<Customer>(customer).State = EntityState.Modified;
            return customer;
        }

        public Customer GetByEmail(string email)
        {
            return _context.Customers
                .AsNoTracking()
                .Include(c => c.AddressList)
                .Include(c => c.CreditCardList)
                .FirstOrDefault(CustomerQueries.GetByEmail(email));
        }

        public Customer GetById(int id)
        {
            return _context.Customers
                .Include(c => c.AddressList)
                .Include(c => c.CreditCardList)
                .FirstOrDefault(CustomerQueries.GetById(id));
        }

        public Customer UpdateCustomerAddressList(Customer customer)
        {
            _context.Entry<Customer>(customer).State = EntityState.Modified;
            return customer;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers
            .Include(c => c.AddressList)
            .Include(c => c.CreditCardList)
            .AsNoTracking()
            .ToList();
        }

        public Customer UpdateCustomerCreditCardList(Customer customer)
        {
            _context.Entry<Customer>(customer).State = EntityState.Modified;
            return customer;
        }

        public Customer GetByUserId(int id)
        {
            return _context.Customers
                .Include(c => c.AddressList)
                .Include(c => c.CreditCardList)
                .FirstOrDefault(CustomerQueries.GetByUserId(id));
        }

        public Customer GetByEmailOrCPF(string email, string cpf)
        {
               return _context.Customers
                .Include(c => c.AddressList)
                .Include(c => c.CreditCardList)
                .FirstOrDefault(CustomerQueries.GetByEmailOrCPF(email, cpf));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Customer> Search(
            string name,
            string lastName,
            string gender,
            string cpf,
            string birthDate,
            string phone,
            string email,
            int? active
        )
        {
            IQueryable<Customer> result = _context.Customers;

            if (name != null)
                result = result.Where(c => c.Name.Contains(name));
            if (lastName != null)
                result = result.Where(c => c.LastName.Contains(lastName));
            if (gender != null)
                result = result.Where(c => c.Gender.Equals(gender));
            if (cpf != null)
                result = result.Where(c => c.CPF.Equals(cpf));
            if (birthDate != null)
                result = result.Where(c => c.BirthDate.Equals(StringToDateTime.Convert(birthDate, "yyyy-MM-dd")));
            if (phone != null)
                result = result.Where(c => c.Phone.Contains(phone));
            if (email != null)
                result = result.Where(c => c.Email.Contains(email));
            if (active != null)
                result = result.Where(c => c.Active == active);      
                
            return result
                .Include(c => c.AddressList)
                .Include(c => c.CreditCardList)
                .AsNoTracking()
                .ToList();
        }
    }
}