using System;
using System.Linq.Expressions;
using Shared;

namespace Domain.MerchandiseContext
{
    public static class CouponQueries
    {
        public static Expression<Func<Coupon, bool>> GetByCustomerId(int id)
        {
            return x => x.CustomerId == id;
        }
    }
}