namespace Shared
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}