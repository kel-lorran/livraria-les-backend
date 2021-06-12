using System.Linq;
using Domain.UserContext;
using Microsoft.EntityFrameworkCore;
using Shared;

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
            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users
            .AsNoTracking()
            .Where(UserQueries.GetByEmail(email))
            .FirstOrDefault();
        }

        public User GetById(int id)
        {
            return _context.Users
            .AsNoTracking()
            .Where(UserQueries.GetById(id))
            .FirstOrDefault();
        }

        public User GetByUserAndPassword(string email, string password)
        {
            return _context.Users
            .AsNoTracking()
            .Where(UserQueries.GetByEmailAndPassword(email, password))
            .FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}