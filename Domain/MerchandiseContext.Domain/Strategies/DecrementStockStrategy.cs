using System.Linq;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class DecrementStockStrategy : IStrategy
    {
        public ICommandResult Execute(Entity entity, IRepository respository)
        {
            var order = (Order) entity;
            var orderRepository = (IOrderRepository) respository;
            var merchandise = order.MerchandiseList.ElementAt(0);
            var result = orderRepository.DecrementMerchandiseStock(merchandise.Id, merchandise.Quantity);
            if(result)
                return new GenericCommandResult(true, "Estoque atualizado");
            return new GenericCommandResult(false, "Não foi possivel atualizar estoque");
        }
    }
}