namespace Domain.CustomerContext
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer GetByEmail(string email);
    }
}