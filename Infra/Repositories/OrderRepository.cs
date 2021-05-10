using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infra
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public DataContext Context { get; }

        public Order CreateDraftOrder(Order order)
        {
            _context.Add(order);
            return order;
        }

        public Order CreatePreviewOrder(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
            return order;
        }

        public List<OrderMerchandise> ComplementMerchandiseList(List<OrderMerchandise> merchandiseList, int orderId = 0)
        {
            var result = new List<OrderMerchandise>();
            var merchandiseRepository = new MerchandiseRepository(_context);

            merchandiseList.ForEach(m => {
                var stockMerchandise = merchandiseRepository.GetByBookId(m.Book.Id);
                var newOrderMerchandise = new OrderMerchandise(stockMerchandise);
                newOrderMerchandise.Quantity = m.Quantity;
                newOrderMerchandise.Status = m.Status;
                result.Add(newOrderMerchandise);
            });

            return result;
        }

        public List<Order> GetAll()
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

        public Order GetDraftById(int id)
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
                .FirstOrDefault(OrderQueries.GetDraftById(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Order UpdateOrder(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
            return order;
        }

        public bool ValidateMerchandiseStock(int orderId, int bookId, int quantity)
        {
            var merchandiseRepository = new MerchandiseRepository(_context);
            var stockMerchandise = merchandiseRepository.GetByBookId(bookId);

            int incremetOrDeclementToStock = quantity;

            var stockQuantityResult = stockMerchandise.Quantity - incremetOrDeclementToStock;

            if(stockQuantityResult > -1)
            {
                return true;
            }
            return false;
        }

        public OrderMerchandise GetMerchandiseByOrderIdAndBookId(int bookId, int orderId = 0)
        {
            OrderMerchandise result = null;
            var _order = _context.Orders
                .Include(o => o.MerchandiseList)
                    .ThenInclude(m => m.Book)
                .FirstOrDefault(OrderQueries.GetById(orderId));

            if(_order != null)
            {
                result = _order.MerchandiseList.FirstOrDefault(m => m.Book.Id == bookId);
            }

            return result;
        }

        public List<Coupon> GetCoupons(string[] couponArr)
        {
            var couponRespository = new CouponRepository(_context);
            return couponRespository.GetByCodes(couponArr);
        }

        public List<CreditCard> GetCards(int[] cardIdArr, int customerId)
        {
            var customerRespository = new CustomerRepository(_context);
            var customer = customerRespository.GetById(customerId);
            var result = new List<CreditCard>();
            customer.CreditCardList.ForEach(c => {
                if (cardIdArr.Contains(c.Id))
                    result.Add(c);
            });
            return result;
        }

        public List<Address> GetAddreses(int customerId)
        {
            var customerRepository = new CustomerRepository(_context);
            var customer = customerRepository.GetById(customerId);
            return customer.AddressList;
        }
    }
}