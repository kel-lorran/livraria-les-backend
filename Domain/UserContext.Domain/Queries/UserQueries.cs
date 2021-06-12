using System;
using System.Linq.Expressions;

namespace Domain.UserContext
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetByEmailAndPassword(string email, string password)
        {
            return x => x.Email == email && x.Password == password;
        }

        public static Expression<Func<User, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }

        public static Expression<Func<User, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}