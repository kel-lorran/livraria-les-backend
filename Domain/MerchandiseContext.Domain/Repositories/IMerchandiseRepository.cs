using System.Collections.Generic;

namespace Domain.MerchandiseContext
{
    public interface IMerchandiseRepository
    {
        Merchandise CreateMerchandise(Merchandise merchandise);
        Merchandise GetById(int id);
        Merchandise UpdateMerchandise(Merchandise merchandise);
        List<Merchandise> GetAllActive();
    }
}