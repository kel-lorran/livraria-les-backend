using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Domain.MerchandiseContext
{
    public class CreateExchangeCouponCommand : ICommand
    {
        private float _value = 0;
        private List<OrderMerchandise> _exchangedMerchandise;
        public CreateExchangeCouponCommand()
        {
        }

        public CreateExchangeCouponCommand(int customerId, List<OrderMerchandise> exchangedMerchandise)
        {
            CustomerId = customerId;
            ExchangedMerchandise = exchangedMerchandise;
        }

        public float Value { get => _value; }
        public string Status { get => "valido"; }
        public string Type { get => "troca"; }
        public string Code { get => (new Random()).Next().ToString(); }
        public DateTime Date { get => DateTime.Now; }
        public int? CustomerId { get; set; }
        public List<OrderMerchandise> ExchangedMerchandise { 
            get => ExchangedMerchandise;
            set {
                _exchangedMerchandise = value;
                _value = _exchangedMerchandise.Aggregate(0, (float ac, OrderMerchandise m) => ac + (m.Quantity * m.Price));
            }
        }
    }
}