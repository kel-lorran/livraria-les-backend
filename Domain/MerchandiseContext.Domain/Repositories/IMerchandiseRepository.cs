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
    }
}