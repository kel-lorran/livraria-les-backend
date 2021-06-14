using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ComplementCategory : IStrategy<Book, IProductRepository>
    {
        public ICommandResult Execute(Book entity, IProductRepository repository)
        {
            var category = repository.GetCategory(entity.Category.Id);
            if(category == null)
                return new GenericCommandResult(false, "Referencia a categoria inexistente");

            entity.Category = category;
            return new GenericCommandResult(true, "Categoria complementada com sucesso");
        }
    }
}