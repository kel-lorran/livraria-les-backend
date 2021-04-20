using Shared;

namespace Domain.MerchandiseContext
{
    public class ProductHandler :
    IHandler<CreateBookCommand>
    {
        private readonly IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBookCommand command)
        {
            var book = new Book(
                command.Author,
                command.Title,
                command.Category,
                command.Publishing,
                command.Edition,
                command.ISBN,
                command.CodeBar,
                command.Year,
                command.PageNumber,
                command.Synopsis,
                command.Height,
                command.Width,
                command.Length,
                command.Weight,
                command.PricingGroup,
                command.Active
            );

            _repository.CreateBook(book);
            return new GenericCommandResult(true, "Livro criado com sucesso", book);
        }
    }
}