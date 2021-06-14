using System.Collections.Generic;
using System.Linq;
using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Utils;

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

        public List<Coupon> Search(
            float value,
            string status,
            string type,
            string code,
            string date,
            int customerId
        )
        {
            IQueryable<Coupon> result = _context.Coupons;

            if (value != 0)
                result = result.Where(c => c.Value == value);
            if (status != null)
                result = result.Where(c => c.Status.Contains(status));
            if (type != null)
                result = result.Where(c => c.Type.Contains(type));
             if (code != null)
                result = result.Where(c => c.Code.Contains(code));
            if (date != null)
                result = result.Where(c => c.Date.Equals(StringToDateTime.Convert(date, "yyyy-MM-dd")));
            if (customerId != 0)
                result = result.Where(c => c.CustomerId == customerId);   
                
            return result
                .AsNoTracking()
                .ToList();
        }
    }
}