using Shared;

namespace Domain.UserContext
{
    public interface IUserRepository : IRepository
    {
        User GetById(int id);
        User GetByUserAndPassword(string email, string password);
        User CreateUser(User user);
        User GetByEmail(string email);
    }
}