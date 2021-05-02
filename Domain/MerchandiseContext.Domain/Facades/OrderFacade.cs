using Shared;

namespace Domain.MerchandiseContext
{
    public class OrderFacade : 
    IFacade<Order, CreateDraftOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public OrderFacade(IOrderRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Execute(Order entity, CreateDraftOrderCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}