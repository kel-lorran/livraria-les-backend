using System.Linq;
using Domain.MerchandiseContext;

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

        public Book GetById(int id)
        {
            return _context.Books
                .FirstOrDefault(ProductQueries.GetById(id));
        }
    }
}