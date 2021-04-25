using System;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class OrderQueries
    {
        public static Expression<Func<Order, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Order, bool>> GetByCustomerId(int id)
        {
            return x => x.CustomerId == id;
        }
    }
}