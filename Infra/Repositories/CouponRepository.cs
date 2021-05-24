using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infra
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DataContext _context;

        public CouponRepository(DataContext context)
        {
            _context = context;
        }

        public Coupon CreateCoupon(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            return coupon;
        }

        public List<Coupon> GetAll()
        {
            return _context.Coupons
            .AsNoTracking()
            .ToList();
        }

        public List<Coupon> GetByCodes(string[] corderArr)
        {
            return _context.Coupons
            .AsNoTracking()
            .Where(CouponQueries.GetByCodes(corderArr))
            .ToList();
        }

        public List<Coupon> GetByCustomerId(int id)
        {
            return _context.Coupons
            .AsNoTracking()
            .Where(CouponQueries.GetByCustomerId(id))
            .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}