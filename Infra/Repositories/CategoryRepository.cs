using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shared;

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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}