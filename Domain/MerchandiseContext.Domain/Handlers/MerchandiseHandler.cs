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
            var merchandise = _repository.GetByBookId(command.BookId);
            string message = "Falha no incremento do estoque verifique o preço de venda pois pode estar inadequado";
            bool insertStatus = true;

            if (merchandise == null)
            {
                merchandise = new StockMerchandise();
                merchandise.Book = command.Book;
                
                insertStatus = merchandise.Increment(command.Price, command.Quantity, command.PriceSeller);

                if(insertStatus) {
                    _repository.CreateMerchandise(merchandise);
                    message = "Estoque de mercadoria criado com sucesso";
                }
            } else
            {
                insertStatus = merchandise.Increment(command.Price, command.Quantity, command.PriceSeller);

                if(insertStatus) {
                    _repository.UpdateMerchandise(merchandise);
                    message = "Estoque de mercadoria incrementado com sucesso";
                }
            }
            
            _repository.SaveChanges();
            return new GenericCommandResult(insertStatus, message, merchandise);
        }

        public ICommandResult Handle(DecrementMerchandiseStockCommand command)
        {
            var merchandise = _repository.GetByBookId(command.BookId);
            string message = "Falha no decremento de mercadoria, verifique a quantidade pois pode estar incoerente com o estoque atual";
            bool insertStatus = true;

            insertStatus = merchandise.Decrement(command.Quantity);

            _repository.UpdateMerchandise(merchandise);
            _repository.SaveChanges();
            return new GenericCommandResult(insertStatus, message, merchandise);
        }
    }
}