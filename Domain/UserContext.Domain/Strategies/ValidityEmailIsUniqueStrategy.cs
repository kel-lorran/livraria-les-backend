using Shared;

namespace Domain.UserContext.Strategy
{
    public class ValidityEmaiIsUniqueStrategy : IStrategy<User, IUserRepository>
    {
        public ICommandResult Execute(User entity, IUserRepository repository)
        {
            if (repository.GetByEmail(entity.Email) != null)
                return new GenericCommandResult(false, "usuário já foi cadastrado anteriormente");
            return new GenericCommandResult(true, "cadastro de usuário cumpre a condição de não pré-existencia");
        }
    }
}