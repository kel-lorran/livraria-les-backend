using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class PriceGroupRepository : IPriceGroupRepository
    {
        private readonly DataContext _context;

        public PriceGroupRepository(DataContext context)
        {
            _context = context;
        }
        public void CreateManyPriceGroup(List<PriceGroup> prices)
        {
            prices.ForEach(p => _context.PriceGroups.Add(p));
        }

        public List<PriceGroup> GetAll()
        {
            return _context.PriceGroups
                .AsNoTracking()
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}