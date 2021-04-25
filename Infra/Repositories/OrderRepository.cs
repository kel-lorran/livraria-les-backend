using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            _context.Add(order);
            _context.SaveChanges();
            return order;
        }

        public List<Order> GetAll()
        {
            return _context.Orders
            .AsNoTracking()
            .ToList();
        }

        public List<Order> GetByCustomerId(int id)
        {
            return _context.Orders
            .AsNoTracking()
            .Where(OrderQueries.GetByCustomerId(id))
            .ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders
                .Include(o => o.MerchandiseList)
                    .ThenInclude(m => m.Book)
                .Include(o => o.ExchangedMerchandise)
                    .ThenInclude(m => m.Book)
                .Include(o => o.CreditCardList)
                .Include(o => o.CouponAppliedList)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.BillingAddress)
                .FirstOrDefault(OrderQueries.GetById(id));
        }

        public Order UpdateOrder(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
            _context.SaveChanges();
            return order;
        }
    }
}