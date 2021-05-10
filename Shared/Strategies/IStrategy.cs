namespace Shared
{
    public interface IStrategy<E, R>
        where E : Identity<E, int>
        where R : IRepository
    {
        ICommandResult Execute(E entity, R repository);
    }
}