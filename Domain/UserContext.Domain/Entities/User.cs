using Shared;

namespace Domain.UserContext
{
    public class User : Identity<User, int>
    {
        public User()
        {
        }

        public User(string email, string role)
        {
            Email = email;
            Role = role;
        }

        public User(string email, string password, string role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}