namespace Domain.CustomerContext
{
    public interface ICustomerRepository
    {
        Customer createCustomer(Customer customer);
    }
}