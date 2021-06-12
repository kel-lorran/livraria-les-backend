using System.Collections.Generic;
using Shared;

namespace Domain.CustomerContext
{
    public interface ICustomerRepository : IRepository
    {
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer GetByEmail(string email);
        Customer GetByEmailOrCPF(string email, string cpf);
        Customer GetByUserId(int id);
        Customer UpdateCustomerAddressList(Customer customer);
        Customer UpdateCustomerCreditCardList(Customer customer);
    }
}