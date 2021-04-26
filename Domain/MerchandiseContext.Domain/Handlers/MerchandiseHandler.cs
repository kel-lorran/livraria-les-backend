using Shared;

namespace Domain.MerchandiseContext
{
    public class MerchandiseHandler :
    IHandler<IncrementMerchandiseStockCommand>,
    IHandler<DecrementMerchandiseStockCommand>
    {
        private readonly IMerchandiseRepository _repository;

        public MerchandiseHandler(IMerchandiseRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(IncrementMerchandiseStockCommand command)
        {
            var merchandise = _repository.GetById(command.BookId);
            string message = "";

            if (merchandise == null) {
                merchandise = new StockMerchandise(
                    command.Price,
                    command.Quantity,
                    command.Book
                );

                _repository.CreateMerchandise(merchandise);
                message = "Estoque de mercadoria criado com sucesso";
            } else {
                merchandise.Quantity += command.Quantity;
                _repository.UpdateMerchandise(merchandise);
                message = "Estoque de mercadoria incrementado com sucesso";
            }
            
            return new GenericCommandResult(true, message, merchandise);
        }

        public ICommandResult Handle(DecrementMerchandiseStockCommand command)
        {
            var merchandise = _repository.GetById(command.BookId);

            merchandise.Quantity -= command.Quantity;
            _repository.UpdateMerchandise(merchandise);
            
            return new GenericCommandResult(true, "Estoque de mercadoria decrementado com sucesso", merchandise);
        }
    }
}