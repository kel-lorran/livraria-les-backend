using Shared;

namespace Domain.CustomerContext
{
    public class UpdateStatusCustomerCommand : ICommand
    {
        public int Active { get; set; }
        public string InativationMessage { get; set; }

        public Customer Entity { get; private set; }

        public Customer MergeEntity(Customer customer)
        {
            customer.Active = Active;
            customer.InativationMessage = InativationMessage;

            Entity = customer;
            return customer;
        }
    }
}