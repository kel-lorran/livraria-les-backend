namespace Shared
{
    public interface ICommandWithValidation : ICommand
    {
        public GenericCommandResult Validate();
    }
}