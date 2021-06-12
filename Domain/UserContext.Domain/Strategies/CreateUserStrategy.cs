using System.Collections.Generic;
using Shared;

namespace Domain.UserContext.Strategy
{
    public class CreateUserStrategy : IStrategy<User, IUserRepository>
    {
        private List<IStrategy<User, IUserRepository>> _strategyList = new List<IStrategy<User, IUserRepository>>(){
            new ValidityEmaiIsUniqueStrategy()
        };

        public ICommandResult Execute(User entity, IUserRepository repository)
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