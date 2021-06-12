using Shared;

namespace Domain.CustomerContext.Strategy
{
    public class ValidityEmaiAndCPFIsUniqueStrategy : IStrategy<Customer, ICustomerRepository>
    {
        public ICommandResult Execute(Customer entity, ICustomerRepository repository)
        {
            if (repository.GetByEmailOrCPF(entity.Email, entity.CPF) != null)
                return new GenericCommandResult(false, "cliente já foi cadastrado anteriormente");
            return new GenericCommandResult(true, "cadastro do cliente cumpre a condição de não pré-existencia");
        }
    }
}