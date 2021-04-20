using Domain.CustomerContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // builder.Property(c => c.Id).ValueGeneratedNever();
            builder.HasMany(t => t.AddressList).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(t => t.CreditCardList).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
