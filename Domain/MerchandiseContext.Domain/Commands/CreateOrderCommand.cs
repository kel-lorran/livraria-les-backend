using System;
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

        public CreateOrderCommand(int customerId, List<OrderMerchandise> merchandiseList, float subTotal, float total, float discount, float shippingPrice, List<CreditCard> creditCardList, List<Coupon> couponAppliedList, Address deliveryAddress, Address billingAddress)
        {
            CustomerId = customerId;
            MerchandiseList = merchandiseList;
            SubTotal = subTotal;
            Total = total;
            Discount = discount;
            ShippingPrice = shippingPrice;
            CreditCardList = creditCardList;
            CouponAppliedList = couponAppliedList;
            DeliveryAddress = deliveryAddress;
            BillingAddress = billingAddress;
        }

        public int CustomerId { get; set; }
        public List<OrderMerchandise> MerchandiseList { get; set; }
        public float SubTotal { get; set; }
        public float Total { get; set; }
        public float Discount { get; set; }
        public float ShippingPrice { get; set; }
        public List<CreditCard> CreditCardList { get; set; }
        public DateTime Date { get => DateTime.Now; }
        public string Status { get => "em processamento"; }
        public List<Coupon> CouponAppliedList { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
    }
}