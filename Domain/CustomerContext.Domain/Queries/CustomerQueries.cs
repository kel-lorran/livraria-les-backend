using System;
using System.Linq.Expressions;

namespace Domain.CustomerContext
{
    public static class CustomerQueries
    {
        public static Expression<Func<Customer, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }

        public static Expression<Func<Customer, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    }
}