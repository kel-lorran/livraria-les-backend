using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infra
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Book CreateBook(Book book)
        {
            _context.Books.Add(book);
            return book;
        }

        public List<Book> GetAllActive()
        {
            return _context.Books
                .Where(BookQueries.GetAllActive())
                .Include(b => b.Category)
                .Include(b => b.PricingGroup)
                .AsNoTracking()
                .ToList();
        }

        public List<Book> GetAllInactive()
        {
            return _context.Books
                .Where(BookQueries.GetAllInactive())
                .Include(b => b.Category)
                .Include(b => b.PricingGroup)
                .AsNoTracking()
                .ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.PricingGroup)
                .FirstOrDefault(ProductQueries.GetById(id));
        }

        public Category GetCategory(int id)
        {
            var categoryRepository = new CategoryRepository(_context);
            return categoryRepository.GetById(id);
        }

        public PriceGroup GetPriceGroup(int id)
        {
            var priceGroupRepository = new PriceGroupRepository(_context);
            return priceGroupRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Book> Search(
            int? active,
            string author,
            string title,
            int? category,
            string publishing,
            string edition,
            string isbn,
            int? year,
            int? pageNumber,
            string synopsis,
            int? height,
            int? width,
            int? weight,
            int? length,
            int? pricingGroup,
            string codeBar
        )
        {
            IQueryable<Book> result = _context.Books;

            if (active != null)
                result = result.Where(b => b.Active == active);
            if (author != null)
                result = result.Where(b => b.Author.Contains(author));
            if (title != null)
                result = result.Where(b => b.Title.Contains(title));
            if (category != null)
                result = result.Where(b => b.Category.Id == category);
            if (publishing != null)
                result = result.Where(b => b.Publishing.Contains(publishing));
            if (edition != null)
                result = result.Where(b => b.Edition.Contains(edition));
            if (isbn != null)
                result = result.Where(b => b.ISBN.Equals(isbn));
            if (year != null)
                result = result.Where(b => b.Year == year);
            if (pageNumber != null)
                result = result.Where(b => b.PageNumber == pageNumber);
            if (synopsis != null)
                result = result.Where(b => b.Synopsis.Contains(synopsis));
            if (height != null)
                result = result.Where(b => b.Height == height);
            if (width != null)
                result = result.Where(b => b.Width == width);
            if (weight != null)
                result = result.Where(b => b.Weight == weight);
            if (length != null)
                result = result.Where(b => b.Length == length);
            if (pricingGroup != null)
                result = result.Where(b => b.PricingGroup.Id == pricingGroup);
            if (codeBar != null)
                result = result.Where(b => b.CodeBar.Equals(codeBar));           
                
            return result
                .Include(b => b.Category)
                .Include(b => b.PricingGroup)
                .AsNoTracking()
                .ToList();
        }

        public Book UpdateBook(Book book)
        {
            _context.Entry<Book>(book).State = EntityState.Modified;
            return book;
        }
    }
}