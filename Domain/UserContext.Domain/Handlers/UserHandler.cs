using Domain.UserContext.Strategy;
using Shared;

namespace Domain.UserContext
{
    public class UserHandler :
        IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            var user = new User(command.Email, command.Password, command.Role);

            var strategy = new CreateUserStrategy();
            var strategyResult = (GenericCommandResult) strategy.Execute(user, _repository);

            if(!strategyResult.Success)
                return strategyResult; 

            _repository.CreateUser(user);
            _repository.SaveChanges();
            return new GenericCommandResult(true, "Usuário criado com sucesso", user);
        }
    }
}