using System.Linq;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ValidateExchangedMerchandiseQuantities : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            var result = true;
            entity.ExchangedMerchandise.ForEach(em => {
                var quantity = entity.MerchandiseList.FirstOrDefault(m => m.Book.Id == em.Book.Id)?.Quantity;
                if (quantity != null)
                    result &= quantity <= em.Quantity;
                else 
                    result = false;
            });

            if (result)
                return new GenericCommandResult(true, "Quantidade de mercadorias trocadas conferem com lista de mercadorias inicial do pedido");
            return new GenericCommandResult(false, "Quantidade de mercadorias trocadas incoerentes com quantidade de mercadorias comprada");
        }
    }
}