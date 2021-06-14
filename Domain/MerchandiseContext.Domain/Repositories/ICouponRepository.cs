using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public interface ICouponRepository : IRepository
    {
        Coupon CreateCoupon(Coupon coupon);
        List<Coupon> GetAll();
        List<Coupon> GetByCustomerId(int id);
        List<Coupon> GetByCodes(string[] corderArr);
        List<Coupon> Search(
            float value,
            string status,
            string type,
            string code,
            string date,
            int customerId
        );
    }
}