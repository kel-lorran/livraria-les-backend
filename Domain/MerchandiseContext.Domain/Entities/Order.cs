using System;
using System.Collections.Generic;
using Domain.Shared.Entities;
using Shared;

namespace Domain.MerchandiseContext
{
    public class Order : Identity<Order, int>
    {
        private List<OrderMerchandise> _exchangedMerchandise = new List<OrderMerchandise>();
        private List<Coupon> _couponAppliedList = new List<Coupon>();
        public Order()
        {
        }

        public Order(int customerId, List<OrderMerchandise> merchandiseList, float subTotal, float total, float discount, float shippingPrice, List<CreditCard> creditCardList, DateTime date, string status, Address deliveryAddress, Address billingAddress)
        {
            CustomerId = customerId;
            MerchandiseList = merchandiseList;
            SubTotal = subTotal;
            Total = total;
            Discount = discount;
            ShippingPrice = shippingPrice;
            CreditCardList = creditCardList;
            Date = date;
            Status = status;
            DeliveryAddress = deliveryAddress;
            BillingAddress = billingAddress;
        }

        public int Id { get => base.Id; set => base.Id = value; }
        public int CustomerId { get; set; }
        public List<OrderMerchandise> MerchandiseList { get; set; }
        public List<OrderMerchandise> ExchangedMerchandise { get => _exchangedMerchandise; set => _exchangedMerchandise = value; }
        public float SubTotal { get; set; }
        public float Total { get; set; }
        public float Discount { get; set; }
        public float ShippingPrice { get; set; }
        public List<CreditCard> CreditCardList { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public List<Coupon> CouponAppliedList { get => _couponAppliedList; set => _couponAppliedList = value; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}