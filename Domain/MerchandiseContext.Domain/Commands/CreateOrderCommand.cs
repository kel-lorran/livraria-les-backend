using System.Collections.Generic;
using Domain.Shared.Entities;
using Shared;

namespace Domain.MerchandiseContext
{
    public class CreateOrderCommand : ICommand
    {
        public CreateOrderCommand()
        {
        }

        public CreateOrderCommand(int customerId, List<Merchandise> merchandiseList, List<Merchandise> exchangedMerchandise, float subTotal, float total, float discount, List<CreditCard> creditCardList, string date, List<Coupon> couponAppliedList, Address deliveryAddress, Address billingAddress)
        {
            CustomerId = customerId;
            MerchandiseList = merchandiseList;
            ExchangedMerchandise = exchangedMerchandise;
            SubTotal = subTotal;
            Total = total;
            Discount = discount;
            CreditCardList = creditCardList;
            Date = date;
            CouponAppliedList = couponAppliedList;
            DeliveryAddress = deliveryAddress;
            BillingAddress = billingAddress;
        }

        public int CustomerId { get; set; }
        public List<Merchandise> MerchandiseList { get; set; }
        public List<Merchandise> ExchangedMerchandise { get; set; }
        public float SubTotal { get; set; }
        public float Total { get; set; }
        public float Discount { get; set; }
        public List<CreditCard> CreditCardList { get; set; }
        public string Date { get; set; }
        public string Status { get => "em processamento"; }
        public List<Coupon> CouponAppliedList { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
    }
}