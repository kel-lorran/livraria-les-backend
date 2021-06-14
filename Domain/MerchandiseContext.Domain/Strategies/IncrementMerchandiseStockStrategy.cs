using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class IncrementMerchandiseStockStrategy : IStrategy<Merchandise, IMerchandiseRepository>
    {
        private List<IStrategy<Merchandise, IMerchandiseRepository>> _strategyList = new List<IStrategy<Merchandise, IMerchandiseRepository>>(){
        };
        public ICommandResult Execute(Merchandise entity, IMerchandiseRepository repository)
        {
            throw new System.NotImplementedException();
        }
    }
}