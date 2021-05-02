using System;

namespace Shared
{
    public interface IFacade<E, C> 
    where E : Entity
    where C : ICommand
    {
        ICommandResult Execute(E entity, C command);
    }
}