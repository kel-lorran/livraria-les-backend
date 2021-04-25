using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public class UpdateOrderExchangedMerchandiseCommand : ICommand
    {
        private List<Merchandise> _exchangedMerchandise;
        public UpdateOrderExchangedMerchandiseCommand()
        {
        }

        public UpdateOrderExchangedMerchandiseCommand(int orderId, List<Merchandise> exchangedMerchandise)
        {
            OrderId = orderId;
            ExchangedMerchandise = exchangedMerchandise;
        }

        public int OrderId { get; set; }
        public List<Merchandise> ExchangedMerchandise { 
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
    }
}