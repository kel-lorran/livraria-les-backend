using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class PriceGroupQueries
    {
        public static Expression<Func<PriceGroup, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}