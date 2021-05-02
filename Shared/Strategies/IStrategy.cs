namespace Shared
{
    public interface IStrategy
    {
        ICommandResult Execute(Entity entity, IRepository respository);
    }
}