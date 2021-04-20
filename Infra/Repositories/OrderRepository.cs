using Domain.MerchandiseContext;

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
    }
}