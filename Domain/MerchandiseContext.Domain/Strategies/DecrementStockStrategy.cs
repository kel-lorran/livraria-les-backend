using System.Linq;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ValidateStockStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            bool result = true;
            
            entity.MerchandiseList.ForEach(m => result &= repository.ValidateMerchandiseStock(entity.Id, m.Book.Id, m.Quantity));

            if(result)
                return new GenericCommandResult(true, "Estoque atualizado");
            return new GenericCommandResult(false, "Não foi possivel atualizar estoque");
        }
    }
}