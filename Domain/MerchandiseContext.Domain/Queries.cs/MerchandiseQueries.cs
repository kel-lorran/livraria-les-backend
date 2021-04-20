using System;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class MerchandiseQueries
    {
        public static Expression<Func<Merchandise, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Merchandise, bool>> GetAllActive()
        {
            return x => x.Book.Active == 1 && x.Quantity > 0;
        }
    }
}