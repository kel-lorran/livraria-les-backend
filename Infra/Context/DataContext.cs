using Domain.CustomerContext;
using Domain.MerchandiseContext;
using Domain.Shared.Entities;
using Domain.UserContext;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Merchandise> Merchandises { get; private set; }
        public DbSet<Order> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new MerchandiseMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}