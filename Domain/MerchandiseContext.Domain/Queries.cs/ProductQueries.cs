using System;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class ProductQueries
    {
        public static Expression<Func<Book, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}