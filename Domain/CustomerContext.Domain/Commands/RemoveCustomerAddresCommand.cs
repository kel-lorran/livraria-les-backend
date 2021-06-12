using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Domain.CustomerContext
{
    public class RemoveCustomerAddresCommand : ICommand
    {
        private List<int> _addressList = new List<int>();
        public RemoveCustomerAddresCommand(List<int> addressList, int customerId, Customer entity)
        {
            AddressList = addressList;
            CustomerId = customerId;
            Entity = entity;
        }

        public List<int> AddressList { get; set; }
        public int CustomerId { get; set; }
        public Customer Entity { get; private set; }

        public Customer MergeEntity(Customer customer)
        {
            var ids = AddressList.ToArray();
            customer.AddressList = customer.AddressList.FindAll(a => ids.Contains(a.Id));

            Entity = customer;
            return customer;
        }
    }
}