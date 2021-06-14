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
                    .ThenInclude(b => b.Category)
                .Where(StockMerchandiseQueries.GetAllActive())
                .AsNoTracking()
                .ToList();
        }

        public StockMerchandise GetById(int id)
        {
            return _context.StockMerchandises
                .Include(m => m.Book)
                    .ThenInclude(b => b.Category)
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
                    .ThenInclude(b => b.Category)
                .FirstOrDefault(StockMerchandiseQueries.GetByBookId(id));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<StockMerchandise> Search(
            string author,
            string title,
            int category,
            string publishing,
            string edition,
            string isbn,
            int year,
            int pageNumber,
            string synopsis,
            string codeBar
        )
        {
            IQueryable<StockMerchandise> result = _context.StockMerchandises
                .Include(m => m.Book)
                    .ThenInclude(b => b.Category)
                .Where(StockMerchandiseQueries.GetAllActive());

            if (author != null)
                result = result.Where(c => c.Book.Author.Contains(author));
            if (title != null)
                result = result.Where(c => c.Book.Title.Contains(title));
            if (category != 0)
                result = result.Where(c => c.Book.Category.Id == category);
            if (publishing != null)
                result = result.Where(c => c.Book.Publishing.Contains(publishing));
            if (edition != null)
                result = result.Where(c => c.Book.Edition.Contains(edition));
            if (isbn != null)
                result = result.Where(c => c.Book.ISBN.Contains(isbn));
            if (year != 0)
                result = result.Where(c => c.Book.Year == year);
            if (pageNumber != 0)
                result = result.Where(c => c.Book.PageNumber == pageNumber);
            if (synopsis != null)
                result = result.Where(c => c.Book.Synopsis.Contains(synopsis));
            if (codeBar != null)
                result = result.Where(c => c.Book.CodeBar.Contains(codeBar));
                
            return result
                .AsNoTracking()
                .ToList();
        }
    }
}