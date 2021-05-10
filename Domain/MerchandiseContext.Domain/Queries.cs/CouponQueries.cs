using System;
using System.Linq;
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
        public static Expression<Func<Coupon, bool>> GetByCodes(string[] codes)
        {
            return x => codes.Contains(x.Code);
        }
    }
}