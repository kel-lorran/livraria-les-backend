using System.Collections.Generic;

namespace Domain.MerchandiseContext
{
    public interface IMerchandiseRepository
    {
        StockMerchandise CreateMerchandise(StockMerchandise merchandise);
        StockMerchandise GetById(int id);
        StockMerchandise GetByBookId(int id);
        StockMerchandise UpdateMerchandise(StockMerchandise merchandise);
        List<StockMerchandise> GetAllActive();
    }
}