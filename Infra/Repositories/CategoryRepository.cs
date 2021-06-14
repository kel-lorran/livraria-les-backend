using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Queries;

namespace Infra
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public void CreateManyCategory(List<Category> categories)
        {
            categories.ForEach(c => _context.Categories.Add(c));
        }

        public List<Category> getAll()
        {
            return _context.Categories
                .Include(c => c.Parent)
                .AsNoTracking()
                .ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories
                .Include(c => c.Parent)
                .FirstOrDefault(CategoryQueries.GetById(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}