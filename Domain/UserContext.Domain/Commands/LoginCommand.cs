using Shared;

namespace Domain.UserContext
{
    public class LoginCommand : ICommand
    {
        public LoginCommand()
        {
        }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}