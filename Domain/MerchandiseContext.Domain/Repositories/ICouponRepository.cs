using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public interface ICouponRepository
    {
        Coupon CreateCoupon(Coupon coupon);
        List<Coupon> GetAll();
        List<Coupon> GetByCustomerId(int id);
        List<Coupon> GetByCodes(string[] corderArr);
    }
}