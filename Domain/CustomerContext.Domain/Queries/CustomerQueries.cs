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

        public static Expression<Func<Customer, bool>> GetByUserId(int id)
        {
            return x => x.UserId == id;
        }

        public static Expression<Func<Customer, bool>> GetByEmailOrCPF(string email, string cpf)
        {
            return x => x.Email == email && x.CPF == cpf;
        }
    }
}