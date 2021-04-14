using System.Linq;
using Domain.CustomerContext;
using Microsoft.EntityFrameworkCore;

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
            _context.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _context.Entry<Customer>(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }

        public Customer GetByEmail(string email)
        {
            return _context.Customers
                .AsNoTracking()
                .Include(c => c.AddressList)
                .FirstOrDefault(CustomerQueries.GetByEmail(email));
        }
    }
}