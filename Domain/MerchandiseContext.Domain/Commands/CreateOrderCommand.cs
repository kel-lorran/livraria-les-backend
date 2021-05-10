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

        public CreateOrderCommand(int id, int customerId, List<CreditCard> creditCardList, List<string> couponAppliedList, Address deliveryAddress, Address billingAddress)
        {
            Id = id;
            CustomerId = customerId;
            CreditCardList = creditCardList;
            CouponAppliedList = couponAppliedList;
            DeliveryAddress = deliveryAddress;
            BillingAddress = billingAddress;
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<CreditCard> CreditCardList { get; set; }
        public string Status { get => "pré-visualização"; }
        public List<string> CouponAppliedList { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address BillingAddress { get; set; }
    }
}