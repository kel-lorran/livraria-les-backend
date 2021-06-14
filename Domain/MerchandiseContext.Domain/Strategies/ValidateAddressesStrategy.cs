using System.Linq;
using Domain.Shared.Entities;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ValidateAddressesStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            var addressList = repository.GetAddreses(entity.CustomerId);

            var deliveryAddress = addressList.FirstOrDefault(
                a => a.CEP.Equals(entity.DeliveryAddress.CEP) && a.HomeNumber.Equals(entity.DeliveryAddress.HomeNumber)
            );

            var billingAddress = addressList.FirstOrDefault(
                a => a.CEP.Equals(entity.BillingAddress.CEP) && a.HomeNumber.Equals(entity.BillingAddress.HomeNumber)
            );

            if(billingAddress != null && deliveryAddress != null)
            {
                // deliveryAddress.Id = 0;
                // billingAddress.Id = 0;
                entity.DeliveryAddress = new Address(deliveryAddress);
                entity.BillingAddress = new Address(billingAddress);
                return new GenericCommandResult(true, "Sucesso na validação de endereços");
            }
            return new GenericCommandResult(false, "Endereço utilizado não consta lista de endereços do usuario");
        }
    }
}