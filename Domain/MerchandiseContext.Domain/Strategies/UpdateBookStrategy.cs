using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class UpdateBookStrategy : IStrategy<Book, IProductRepository>
    {
        private List<IStrategy<Book, IProductRepository>> _strategyList = new List<IStrategy<Book, IProductRepository>>(){
            new ComplementCategory(),
            new ComplementPriceGroup()
        };

        public ICommandResult Execute(Book entity, IProductRepository repository)
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