using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public interface IMerchandiseRepository : IRepository
    {
        StockMerchandise CreateMerchandise(StockMerchandise merchandise);
        StockMerchandise GetById(int id);
        StockMerchandise GetByBookId(int id);
        StockMerchandise UpdateMerchandise(StockMerchandise merchandise);
        List<StockMerchandise> GetAllActive();
        List<StockMerchandise> Search(
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
        );
    }
}