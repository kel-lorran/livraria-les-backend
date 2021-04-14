using System.Collections.Generic;
using Shared;

namespace Domain.CustomerContext
{
    public class CustomerHandler : 
        IHandler<CreateCustomerCommand>,
        IHandler<UpdateCustomerPersonDataCommand>
    {
        private readonly ICustomerRepository _repository;

        public CustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            var address = new Address(
                command.HomeType,
                command.PublicPlaceType,
                command.PublicPlaceName,
                command.HomeNumber,
                command.CEP,
                command.Neighborhood,
                command.City,
                command.State,
                command.Country,
                command.Complement,
                command.AddressLabel
            );

            var customer = new Customer(
                command.Name,
                command.LastName,
                command.Gender,
                command.CPF,
                command.BirthDate,
                command.Phone,
                command.Email,
                command.Active,
                new List<Address>{address}
            );

            _repository.CreateCustomer(customer);
            return new GenericCommandResult(true, "Sucesso no registro do cliente", customer);
        }

        public ICommandResult Handle(UpdateCustomerPersonDataCommand command)
        {
            var customer = _repository.GetByEmail(command.Email);
            command.MergeEntity(customer);
            _repository.UpdateCustomer(customer);
            return new GenericCommandResult(true, "Sucesso na atualização do registro do cliente", customer);
        }
    }
}