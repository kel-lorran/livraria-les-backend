using System.Linq;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class CalculeTotalStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            entity.Total = entity.SubTotal - entity.Discount;

            return new GenericCommandResult(true, "Subtotal do pedido calculado");
        }
    }
}