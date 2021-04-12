using Domain.CustomerContext;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}