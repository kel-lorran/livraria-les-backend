using Domain.Shared.Entities;
using Shared;

namespace Domain.MerchandiseContext
{
    public class CommitNewOrderCommand : ICommand
    {
        public CommitNewOrderCommand(int id, Address billingAddress)
        {
            Id = id;
            BillingAddress = billingAddress;
        }

        public int Id { get; set; }
        public Address BillingAddress { get; set; }
        public string Status { get => "em processamento"; }

        public Order Entity { get; private set; }

        public void SetEntity (Order order) => Entity = order;

        public Order MergeEntity(Order _order)
        {
            if(_order.BillingAddress.Id != BillingAddress.Id)
                _order.BillingAddress = BillingAddress;

            _order.Status = Status;
            Entity = _order;
            return _order;
        }
    }
}