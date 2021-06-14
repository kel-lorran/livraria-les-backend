using System.Collections.Generic;

namespace Shared
{
    public interface ICategoryRepository : IRepository
    {
       void CreateManyCategory(List<Category> categories);
       List<Category> getAll();
       Category GetById(int id);
    }
}