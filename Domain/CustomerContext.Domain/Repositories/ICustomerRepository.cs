using System.Collections.Generic;

namespace Domain.CustomerContext
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer GetByEmail(string email);
        Customer UpdateCustomerAddressList(Customer customer);
        Customer UpdateCustomerCreditCardList(Customer customer);
    }
}