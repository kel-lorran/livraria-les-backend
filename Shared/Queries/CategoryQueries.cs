using System;
using System.Linq.Expressions;

namespace Shared.Queries
{
    public static class CategoryQueries
    {
        public static Expression<Func<Category, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
    } 
}