using System.Collections.Generic;
using Shared;

namespace Domain.MerchandiseContext
{
    public interface IPriceGroupRepository : IRepository
    {
        void CreateManyPriceGroup(List<PriceGroup> prices);
        List<PriceGroup> GetAll();
        PriceGroup GetById(int id);
    }
}