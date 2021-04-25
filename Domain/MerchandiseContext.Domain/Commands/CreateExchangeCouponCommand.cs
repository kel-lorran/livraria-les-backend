using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Domain.MerchandiseContext
{
    public class CreateExchangeCouponCommand : ICommand
    {
        private float _value = 0;
        private List<Merchandise> _exchangedMerchandise;
        public CreateExchangeCouponCommand()
        {
        }

        public CreateExchangeCouponCommand(int customerId, List<Merchandise> exchangedMerchandise)
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
        public List<Merchandise> ExchangedMerchandise { 
            get => ExchangedMerchandise;
            set {
                _exchangedMerchandise = value;
                _value = _exchangedMerchandise.Aggregate(0, (float ac, Merchandise m) => ac + (m.Quantity * m.Price));
            }
        }
    }
}