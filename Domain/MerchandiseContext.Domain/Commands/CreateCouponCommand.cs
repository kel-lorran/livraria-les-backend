using System;
using Shared;

namespace Domain.MerchandiseContext
{
    public class CreateCouponCommand : ICommand
    {
        public CreateCouponCommand()
        {
        }

        public CreateCouponCommand(float value, string type)
        {
            Value = value;
            Type = type;
        }

        public float Value { get; set; }
        public string Status { get => "valido"; }
        public string Type { get; set; }
        public string Code { get => (new Random()).Next().ToString(); }
        public DateTime Date { get => DateTime.Now; }
        public int? CustomerId { get; set; }
    }
}