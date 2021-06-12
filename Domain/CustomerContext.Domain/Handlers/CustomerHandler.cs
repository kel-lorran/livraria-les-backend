using System.Collections.Generic;
using Domain.CustomerContext.Strategy;
using Domain.Shared.Entities;
using Shared;
using Shared.Utils;

namespace Domain.CustomerContext
{
    public class CustomerHandler : 
        IHandler<CreateCustomerCommand>,
        IHandler<UpdateCustomerPersonDataCommand>,
        IHandler<CreateCustomerAddresCommand>,
        IHandler<CreateCustomerCreditCardCommand>,
        IHandler<RemoveCustomerAddresCommand>
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
                command.UserId,
                command.Name,
                command.LastName,
                command.Gender,
                command.CPF,
                StringToDateTime.Convert(command.BirthDate, "yyyy-MM-dd"),
                command.Phone,
                command.Email,
                command.Active,
                new List<Address>{address}
            );

            var strategy = new CreateCustomerStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(customer, _repository);

            if(!strategyResult.Success)
                return strategyResult; 

            _repository.CreateCustomer(customer);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Sucesso no registro do cliente", customer);
        }

        public ICommandResult Handle(UpdateCustomerPersonDataCommand command)
        {
            var customer = _repository.GetByEmail(command.Email);
            command.MergeEntity(customer);
            _repository.UpdateCustomer(customer);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Sucesso na atualização do registro do cliente", customer);
        }

        public ICommandResult Handle(CreateCustomerAddresCommand command)
        {
            var customer = _repository.GetById(command.CustomerId);

            if(customer == null)
                return new GenericCommandResult(false, "Cliente não encontrado", null);

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

            customer.AddressList.Add(address);
            _repository.UpdateCustomerAddressList(customer);
            _repository.SaveChanges();

            return new GenericCommandResult(true, "Endereço adicionado com sucesso", customer);
        }

        public ICommandResult Handle(CreateCustomerCreditCardCommand command)
        {
            var customer = _repository.GetById(command.CustomerId);

            if(customer == null)
                return new GenericCommandResult(false, "Cliente não encontrado", null);

            var creditCard = new CreditCard(
                command.CreditCardCompany,
                command.CardNumber,
                StringToDateTime.Convert(command.Validity, "M/yyyy"),
                command.Label
            );

            customer.CreditCardList.Add(creditCard);
            _repository.UpdateCustomerCreditCardList(customer);
            _repository.SaveChanges();

            return new GenericCommandResult(true, "Cartão adicionado com sucesso", customer);
        }

        public ICommandResult Handle(RemoveCustomerAddresCommand command)
        {
            var customer = _repository.GetById(command.CustomerId);

            if(customer == null)
                return new GenericCommandResult(false, "Cliente não encontrado", null);

            command.MergeEntity(customer);

            _repository.UpdateCustomerCreditCardList(customer);
            _repository.SaveChanges();

            return new GenericCommandResult(true, "Endereço(s) removidos com sucesso", customer);
        }
    }
}