using Domain.MerchandiseContext.Strategy;
using Shared;

namespace Domain.MerchandiseContext
{
    public class ProductHandler :
    IHandler<CreateBookCommand>,
    IHandler<UpdateBookCommand>,
    IHandler<UpdateStatusBookCommand>
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
                new Category(command.Category),
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
                new PriceGroup(command.PricingGroup),
                command.Active
            );

            var strategy = new CreateBookStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(book, _repository);

            if(!strategyResult.Success)
                return strategyResult;

            _repository.CreateBook(book);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Livro criado com sucesso", book);
        }

        public ICommandResult Handle(UpdateBookCommand command)
        {
            var book = command.Entity;

            var strategy = new UpdateBookStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(book, _repository);

            if(!strategyResult.Success)
                return strategyResult;

            _repository.UpdateBook(book);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Livro atualizado com sucesso", book);
        }

        public ICommandResult Handle(UpdateStatusBookCommand command)
        {
            var book = command.Entity;

            _repository.UpdateBook(book);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Livro atualizado com sucesso", book);
        }
    }
}