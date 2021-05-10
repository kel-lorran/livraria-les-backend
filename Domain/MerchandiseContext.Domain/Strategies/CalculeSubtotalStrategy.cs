using System.Linq;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class CalculeSubtotalStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            var subtotal = 0f;
            entity.MerchandiseList.ForEach(m => subtotal += (m.Price * m.Quantity));
            entity.SubTotal = subtotal;

            return new GenericCommandResult(true, "Subtotal do pedido calculado");
        }
    }
}