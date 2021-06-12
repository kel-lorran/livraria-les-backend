using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class BookQueries
    {
        public static Expression<Func<Book, bool>> GetAllActive()
        {
            return x => x.Active == 1;
        }
        public static Expression<Func<Book, bool>> GetAllInactive()
        {
            return x => x.Active == 0;
        }
    }
}