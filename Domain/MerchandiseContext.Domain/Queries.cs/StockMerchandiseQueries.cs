using System;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class StockMerchandiseQueries
    {
        public static Expression<Func<StockMerchandise, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<StockMerchandise, bool>> GetByBookId(int id)
        {
            return x => x.Book.Id == id;
        }
        public static Expression<Func<StockMerchandise, bool>> GetAllActive()
        {
            // return x => x.Book.Active == 1 && x.Quantity > 0;
            return x => true;
        }
    }
}