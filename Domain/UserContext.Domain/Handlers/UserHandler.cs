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
            _repository.CreateUser(user);
            return new GenericCommandResult(true, "Usuário criado com sucesso", user);
        }
    }
}