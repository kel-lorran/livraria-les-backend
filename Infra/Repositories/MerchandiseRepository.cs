using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class MerchandiseRepository : IMerchandiseRepository
    {
        private readonly DataContext _context;

        public MerchandiseRepository(DataContext context)
        {
            _context = context;
        }

        public StockMerchandise CreateMerchandise(StockMerchandise merchandise)
        {
            _context.StockMerchandises.Add(merchandise);
            _context.SaveChanges();
            return merchandise;
        }

        public List<StockMerchandise> GetAllActive()
        {
            return _context.StockMerchandises
                .Include(m => m.Book)
                .Where(StockMerchandiseQueries.GetAllActive())
                .AsNoTracking()
                .ToList();
        }

        public StockMerchandise GetById(int id)
        {
            return _context.StockMerchandises
                .Include(m => m.Book)
                .FirstOrDefault(StockMerchandiseQueries.GetById(id));
        }

        public StockMerchandise UpdateMerchandise(StockMerchandise merchandise)
        {
            _context.Entry<StockMerchandise>(merchandise).State = EntityState.Modified;
            return merchandise;
        }

        public StockMerchandise GetByBookId(int id)
        {
            return _context.StockMerchandises
                .Include(m => m.Book)
                .FirstOrDefault(StockMerchandiseQueries.GetByBookId(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}