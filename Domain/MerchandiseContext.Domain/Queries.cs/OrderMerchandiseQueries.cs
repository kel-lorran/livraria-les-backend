using System;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class OrderMerchandiseQueries
    {
        public static Expression<Func<OrderMerchandise, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<OrderMerchandise, bool>> GetByBookId(int id)
        {
            return x => x.Book.Id == id;
        }
        public static Expression<Func<OrderMerchandise, bool>> GetAllActive()
        {
            return x => x.Book.Active == 1 && x.Quantity > 0;
        }
    }
}