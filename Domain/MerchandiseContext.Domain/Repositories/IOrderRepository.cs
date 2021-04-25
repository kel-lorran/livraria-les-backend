using System.Collections.Generic;

namespace Domain.MerchandiseContext
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order GetById(int id);
        Order UpdateOrder(Order order);
        List<Order> GetAll();
        List<Order> GetByCustomerId(int id);
    }
}