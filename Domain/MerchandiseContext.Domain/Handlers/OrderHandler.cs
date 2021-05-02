using Domain.MerchandiseContext.Strategy;
using Shared;
using Shared.Utils;

namespace Domain.MerchandiseContext
{
    public class OrderHandler :
    IHandler<CreateOrderCommand>,
    IHandler<UpdateOrderStatusCommand>,
    IHandler<UpdateOrderExchangedMerchandiseCommand>,
    IHandler<CreateDraftOrderCommand>
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
                command.SubTotal,
                command.Total,
                command.Discount,
                command.ShippingPrice,
                command.CreditCardList,
                command.Date,
                command.Status,
                command.DeliveryAddress,
                command.BillingAddress
            );

            if(command.CouponAppliedList != null)
                order.CouponAppliedList = command.CouponAppliedList;

            _repository.CreateOrder(order);
            //_repository.SaveChanges();

            return new GenericCommandResult(true, "Pedido de compra criado com sucesso", order);
        }

        public ICommandResult Handle(UpdateOrderStatusCommand command)
        {
            var order = _repository.GetById(command.OrderId);

            order.Status = command.Status;
            if(order.Status == "troca autorizada")
            {
                foreach (var exMerchandise in order.ExchangedMerchandise)
                {
                    exMerchandise.Status = exMerchandise.Status == "nao processada" ? "aprovada - aguardando recebimento" : exMerchandise.Status;
                }
            }
            _repository.UpdateOrder(order);
            return new GenericCommandResult(true, "Status do pedido atualizado com sucesso", order);
        }

        public ICommandResult Handle(UpdateOrderExchangedMerchandiseCommand command)
        {
            var order = _repository.GetById(command.OrderId);

            order.ExchangedMerchandise = command.ExchangedMerchandise;
            order.Status = "em troca";
            _repository.UpdateOrder(order);
            return new GenericCommandResult(true, "Pedido de troca registrado com sucesso", order);
        }

        public ICommandResult Handle(CreateDraftOrderCommand command)
        {
            var order = new Order();

            order.MerchandiseList = command.MerchandiseList;
            order.Date = command.Date;
            order.Status = command.Status;

            if(command.CustomerId > 0)
                order.CustomerId = command.CustomerId;

            // var strategy = new CreateDraftOrderStrategy();
            // var strategyResult = (GenericCommandResult) strategy.Execute(order, _repository);

            // if(!strategyResult.Success)
            //     return strategyResult;

            _repository.CreateOrder(order);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Pedido de compra tipo rascunho criado com sucesso", order);
        }
    }
}