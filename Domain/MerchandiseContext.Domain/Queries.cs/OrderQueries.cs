using System;
using System.Linq.Expressions;

namespace Domain.MerchandiseContext
{
    public static class OrderQueries
    {
        public static Expression<Func<Order, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Order, bool>> GetByCustomerId(int id)
        {
            return x => x.CustomerId == id;
        }

        public static Expression<Func<Order, bool>> GetDraftById(int id)
        {
            return x => x.Id == id && x.Status.Equals("rascunho");
        }

        public static Expression<Func<Order, bool>> GetByPeriod(DateTime initialDate, DateTime finalDate)
        {
            return x => (DateTime.Compare(x.Date, initialDate) >= 0)
                && (DateTime.Compare(x.Date, finalDate) <= 0)
                && !x.Status.Equals("rascunho")
                && !x.Status.Equals("pré-visualização");
        }
    }
}