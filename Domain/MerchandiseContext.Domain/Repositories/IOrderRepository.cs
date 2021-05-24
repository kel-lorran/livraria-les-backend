using System;
using System.Collections.Generic;
using Domain.Shared.Entities;
using Shared;

namespace Domain.MerchandiseContext
{
    public interface IOrderRepository : IRepository
    {
        Order CreateDraftOrder(Order order);
        Order CreatePreviewOrder(Order order);
        Order GetById(int id);
        Order UpdateOrder(Order order);
        List<Order> GetAll();
        List<Order> GetAllByPeriod(DateTime initialDate, DateTime finalDate);
        List<Order> GetByCustomerId(int id);
        bool ValidateMerchandiseStock(int orderId, int bookId, int quantity);
        Order GetDraftById(int id);
        OrderMerchandise GetMerchandiseByOrderIdAndBookId(int orderId, int bookId);
        List<Coupon> GetCoupons(string[] couponArr);
        List<CreditCard> GetCards(int[] cardIdArr, int customerId);
        List<Address> GetAddreses(int customerId);
        List<OrderMerchandise> ComplementMerchandiseList(List<OrderMerchandise> merchandiseList, int orderId = 0);

        Coupon CreateCouponInChange(Coupon coupon);
    }
}