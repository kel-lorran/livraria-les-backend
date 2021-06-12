using System.Collections.Generic;
using Shared;

namespace Domain.CustomerContext.Strategy
{
    public class CreateCustomerStrategy : IStrategy<Customer, ICustomerRepository>
    {
        private List<IStrategy<Customer, ICustomerRepository>> _strategyList = new List<IStrategy<Customer, ICustomerRepository>>(){
            new ValidityEmaiAndCPFIsUniqueStrategy()
        };

        public ICommandResult Execute(Customer entity, ICustomerRepository repository)
        {
            GenericCommandResult result = new GenericCommandResult();
            foreach(var s in _strategyList)
            {
                result = (GenericCommandResult) s.Execute(entity, repository);
                if(!result.Success)
                    break;
            }
            return result;
        }
    }
}