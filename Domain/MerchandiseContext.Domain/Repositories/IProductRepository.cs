using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public interface IProductRepository : IRepository
    {
        Book CreateBook(Book book);
        Book UpdateBook(Book book);
        Book GetById(int id);
        List<Book> GetAllActive();
        List<Book> GetAllInactive();
        Category GetCategory(int id);
        PriceGroup GetPriceGroup(int id);
        List<Book> Search(
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
        );
    }
}