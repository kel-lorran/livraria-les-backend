using System.Linq;
using Domain.MerchandiseContext.Strategy;
using Shared;
using Shared.Utils;

namespace Domain.MerchandiseContext
{
    public class OrderHandler :
    IHandler<CreateOrderCommand>,
    IHandler<UpdateOrderStatusCommand>,
    IHandler<UpdateOrderExchangedMerchandiseCommand>,
    IHandler<CreateDraftOrderCommand>,
    IHandler<UpdateDraftOrderCommand>,
    IHandler<CommitNewOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public OrderHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            var order = _repository.GetDraftById(command.Id);
            order.CustomerId = command.CustomerId;
            order.CreditCardList = command.CreditCardList;
            order.Status = command.Status;
            if(command.CouponAppliedList.Count > 0)
                order.CouponAppliedList = command.CouponAppliedList.Select(c => new Coupon(c)).ToList();
            order.DeliveryAddress = command.DeliveryAddress;
            order.BillingAddress = command.BillingAddress;

            var strategy = new CreateOrderStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(order, _repository);

            if(!strategyResult.Success)
                return strategyResult;

            _repository.CreatePreviewOrder(order);
            _repository.SaveChanges();

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
            if(order.Status == "mercadoria devolvida")
            {
                foreach (var exMerchandise in order.ExchangedMerchandise)
                {
                    var returnStockStatus = command.ReturnStock ? " retornar ao estoque" : "";
                    exMerchandise.Status = exMerchandise.Status == "aprovada - aguardando recebimento" ? "mercadoria devolvida" + returnStockStatus : exMerchandise.Status;
                }
            }
            _repository.UpdateOrder(order);
            _repository.SaveChanges();

            return new GenericCommandResult(true, "Status do pedido atualizado com sucesso", order);
        }

        public ICommandResult Handle(UpdateOrderExchangedMerchandiseCommand command)
        {
            var order = command.Entity;
            order.Status = "em troca";

            var strategy = new UpdateOrderExchangedMerchandiseStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(order, _repository);

            if(!strategyResult.Success)
                return strategyResult;

            var _exchangedMerchandise = _repository.ComplementMerchandiseList(order.ExchangedMerchandise, order.Id);
            order.ExchangedMerchandise = _exchangedMerchandise;
            _repository.UpdateOrder(order);
            _repository.SaveChanges();

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

            var strategy = new CreateDraftOrderStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(order, _repository);

            if(!strategyResult.Success)
                return strategyResult;

            var _merchandiseList = _repository.ComplementMerchandiseList(order.MerchandiseList, order.Id);
            order.MerchandiseList = _merchandiseList;
            _repository.CreateDraftOrder(order);
            _repository.SaveChanges();

            return new GenericCommandResult(true, "Pedido de compra tipo rascunho criado com sucesso", order);
        }

        public ICommandResult Handle(UpdateDraftOrderCommand command)
        {
            var order = _repository.GetDraftById(command.Id);
            order.MerchandiseList = command.MerchandiseList;

            if(command.CustomerId > 0)
                order.CustomerId = command.CustomerId;


            var strategy = new UpdateDraftOrderStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(order, _repository);

            if(!strategyResult.Success)
                return strategyResult;

            var _merchandiseList = _repository.ComplementMerchandiseList(order.MerchandiseList, order.Id);
            order.MerchandiseList = _merchandiseList;
            _repository.UpdateOrder(order);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Pedido de compra tipo rascunho atualizado com sucesso", order);
        }

        public ICommandResult Handle(CommitNewOrderCommand command)
        {
            var order = command.Entity;

            var strategy = new CommitNewOrderStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(order, _repository);

            if(!strategyResult.Success)
                return strategyResult;

            _repository.UpdateOrder(order);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Pedido de compra finaliza com sucesso", order);
        }
    }
}