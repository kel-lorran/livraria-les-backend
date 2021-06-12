using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;

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
            _context.SaveChanges();
            return book;
        }

        public List<Book> GetAllActive()
        {
            return _context.Books
                .Where(BookQueries.GetAllActive())
                .AsNoTracking()
                .ToList();
        }

        public List<Book> GetAllInactive()
        {
            return _context.Books
                .Where(BookQueries.GetAllInactive())
                .AsNoTracking()
                .ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books
                .FirstOrDefault(ProductQueries.GetById(id));
        }
    }
}