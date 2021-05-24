using System;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ManagerRestStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            var message = "Não foi necessario cupon de troco";
            if (entity.Total < 0) {
                var changeCoupon = new Coupon {
                    Value = entity.Total * -1,
                    Status = "valido",
                    Type = "troco",
                    Code = (new Random()).Next().ToString(),
                    Date = DateTime.Now,
                    CustomerId = entity.CustomerId
                };
                repository.CreateCouponInChange(changeCoupon);
                message = "Cupon de troco criado com sucesso";
            }
            return new GenericCommandResult(true, message);
        }
    }
}