using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public interface IOrderRepository : IRepository
    {
        Order CreateOrder(Order order);
        Order GetById(int id);
        Order UpdateOrder(Order order);
        List<Order> GetAll();
        List<Order> GetByCustomerId(int id);
        bool DecrementMerchandiseStock(int id, int quantity);
    }
}