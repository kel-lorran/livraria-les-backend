using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class DiscartAppliedCouponsStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            entity.CouponAppliedList.ForEach(c => {
                if (c.Type.Equals("troca") || c.Type.Equals("troco"))
                    c.Status = "utilizado";
            });
            return new GenericCommandResult(true, "Cupons atualizados para o status utlizado");
        }
    }
}