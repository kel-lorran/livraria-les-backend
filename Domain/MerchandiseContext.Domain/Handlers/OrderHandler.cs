using Shared;
using Shared.Utils;

namespace Domain.MerchandiseContext
{
    public class OrderHandler :
    IHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public OrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            var order = new Order(
                command.CustomerId,
                command.MerchandiseList,
                command.ExchangedMerchandise,
                command.SubTotal,
                command.Total,
                command.Discount,
                command.CreditCardList,
                StringToDateTime.Convert(command.Date),
                command.Status,
                command.CouponAppliedList,
                command.DeliveryAddress,
                command.BillingAddress
            );

            _repository.CreateOrder(order);

            return new GenericCommandResult(true, "Pedido de compra criado com sucesso", order);
        }
    }
}