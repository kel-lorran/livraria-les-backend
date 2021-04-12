using System.Linq;
using Domain.UserContext;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetByUserAndPassword(string email, string password)
        {
            return _context.Users.AsNoTracking().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}