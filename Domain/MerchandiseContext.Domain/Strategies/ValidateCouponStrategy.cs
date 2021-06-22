using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ValidateCouponStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            List<Coupon> result = new List<Coupon>();
            if (entity.CouponAppliedList.Count > 0)
            {
                var codeArr = entity.CouponAppliedList.Select(c => c.Code).ToArray();
                var couponAppliedListFromDb = repository.GetCoupons(codeArr);

                var promotionalCoupon = couponAppliedListFromDb
                    .Where(c => c.Type.Equals("promotional") && c.Status.Equals("valido"))
                    .OrderByDescending(c => c.Value)
                    .FirstOrDefault(c => true);

                var couponAppliedListExchange = couponAppliedListFromDb
                    .Where(c => (c.Type.Equals("troca") || c.Type.Equals("troco")) && c.Status.Equals("valido"))
                    .OrderBy(c => c.Value)
                    .ToList();

                var discount = 0f;
                if(promotionalCoupon != null)
                {
                    discount += (promotionalCoupon.Value < 1.001 ? promotionalCoupon.Value * entity.SubTotal : promotionalCoupon.Value);
                    result.Add(promotionalCoupon);
                }

                couponAppliedListExchange.ForEach(c => {
                    if(discount < entity.SubTotal)
                    {
                        discount += c.Value;
                        result.Add(c);
                    }
                });

                entity.Discount = discount;
            }
            entity.CouponAppliedList = result;
            return new GenericCommandResult(true, "Lista de coupon atualizada segundo o banco de dados");
        }
    }
}