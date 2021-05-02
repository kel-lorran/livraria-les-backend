using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class CreateDraftOrderStrategy : IStrategy
    {
        private List<IStrategy> _strategyList = new List<IStrategy>(){
            new DecrementStockStrategy()
        };
        public ICommandResult Execute(Entity entity, IRepository respository)
        {
            GenericCommandResult result = new GenericCommandResult();
            foreach(var s in _strategyList)
            {
                result = (GenericCommandResult) s.Execute(entity, respository);
                if(!result.Success)
                    break;
            }
            return result;
        }
    }
}