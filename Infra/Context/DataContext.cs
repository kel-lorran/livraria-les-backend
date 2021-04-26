using Domain.CustomerContext;
using Domain.MerchandiseContext;
using Domain.Shared.Entities;
using Domain.UserContext;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; private set; }
        public DbSet<Customer> Customers { get; private set;}
        public DbSet<Address> Addresses { get; private set; }
        public DbSet<CreditCard> CreditCards { get; private set; }
        public DbSet<Book> Books { get; private set; }
        public DbSet<StockMerchandise> StockMerchandises { get; private set; }
        public DbSet<OrderMerchandise> OrderMerchandises { get; private set; }
        public DbSet<Order> Orders { get; private set; }
        public DbSet<Coupon> Coupons { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new StockMerchandiseMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new AddressMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}