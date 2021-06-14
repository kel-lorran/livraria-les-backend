using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ComplementPriceGroup : IStrategy<Book, IProductRepository>
    {
        public ICommandResult Execute(Book entity, IProductRepository repository)
        {
            var pG = repository.GetPriceGroup(entity.PricingGroup.Id);
            if(pG == null)
                return new GenericCommandResult(false, "Referencia a grupo de precificação inexistente");

            entity.PricingGroup = pG;
            return new GenericCommandResult(true, "Grupo de precificação complementado com sucesso");
        }
    }
}