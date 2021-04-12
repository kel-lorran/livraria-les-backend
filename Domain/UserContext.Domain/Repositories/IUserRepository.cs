namespace Domain.UserContext
{
    public interface IUserRepository
    {
        User GetByUserAndPassword(string email, string password);
        User CreateUser(User user);
    }
}