using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class UpdateOrderExchangedMerchandiseStrategy : IStrategy<Order, IOrderRepository>
    {
        private List<IStrategy<Order, IOrderRepository>> _strategyList = new List<IStrategy<Order, IOrderRepository>>(){
        };

        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            GenericCommandResult result = new GenericCommandResult();
            foreach(var s in _strategyList)
            {
                result = (GenericCommandResult) s.Execute(entity, repository);
                if(!result.Success)
                    break;
            }
            return result;
        }
    }
}