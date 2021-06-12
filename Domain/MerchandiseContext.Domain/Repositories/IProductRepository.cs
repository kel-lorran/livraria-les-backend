using System.Collections.Generic;

namespace Domain.MerchandiseContext
{
    public interface IProductRepository
    {
        Book CreateBook(Book book);
        Book GetById(int id);
        List<Book> GetAllActive();
        List<Book> GetAllInactive();
    }
}