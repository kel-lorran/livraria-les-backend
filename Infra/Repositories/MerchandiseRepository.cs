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

        public Merchandise CreateMerchandise(Merchandise merchandise)
        {
            _context.Merchandises.Add(merchandise);
            _context.SaveChanges();
            return merchandise;
        }

        public List<Merchandise> GetAllActive()
        {
            return _context.Merchandises
                .Include(m => m.Book)
                .Where(MerchandiseQueries.GetAllActive())
                .AsNoTracking()
                .ToList();
        }

        public Merchandise GetById(int id)
        {
            return _context.Merchandises
                .Include(m => m.Book)
                .FirstOrDefault(MerchandiseQueries.GetById(id));
        }

        public Merchandise UpdateMerchandise(Merchandise merchandise)
        {
            _context.Entry<Merchandise>(merchandise).State = EntityState.Modified;
            _context.SaveChanges();
            return merchandise;
        }
    }
}