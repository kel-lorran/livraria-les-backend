using System.Collections.Generic;
using System.Linq;
using Domain.Shared.Entities;
using Shared;

namespace Domain.MerchandiseContext.Strategy
{
    public class ValidateCreditCardStrategy : IStrategy<Order, IOrderRepository>
    {
        public ICommandResult Execute(Order entity, IOrderRepository repository)
        {
            var result = new List<CreditCard>();
            var cardIdArr = entity.CreditCardList.Select(c => c.Id).ToArray();
            var creditCardListFromDb = repository.GetCards(cardIdArr, entity.CustomerId);

            if (creditCardListFromDb.Count > 0)
                result.Add(creditCardListFromDb.First());
            else
                return new GenericCommandResult(false, "Nenhum cartão de credito confere com os do cliente já cadastrados");

            if  (entity.Total < 20 && creditCardListFromDb.Count > 1)
                result.Add(creditCardListFromDb.ElementAt(1));

            entity.CreditCardList = result;
            return new GenericCommandResult(true, "Lista de coupon atualizada segundo o banco de dados");
        }
    }
}