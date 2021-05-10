using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public class UpdateOrderExchangedMerchandiseCommand : ICommand
    {
        private List<OrderMerchandise> _exchangedMerchandise;
        public UpdateOrderExchangedMerchandiseCommand()
        {
        }

        public UpdateOrderExchangedMerchandiseCommand(int orderId, List<OrderMerchandise> exchangedMerchandise)
        {
            OrderId = orderId;
            ExchangedMerchandise = exchangedMerchandise;
        }

        public int OrderId { get; set; }
        public List<OrderMerchandise> ExchangedMerchandise { 
            get => _exchangedMerchandise; 
            set
            {
                foreach (var merchandise in value)
                {
                    merchandise.Status = "nao processada";
                }
                _exchangedMerchandise = value;
            }
        }

        public Order Entity { get; private set; }

        public void SetEntity (Order order) => Entity = order;

        public Order MergeEntity(Order _order)
        {
            _order.ExchangedMerchandise = ExchangedMerchandise;

            Entity = _order;
            return _order;
        }
    }
}