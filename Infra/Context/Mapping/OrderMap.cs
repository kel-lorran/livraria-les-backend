using Domain.MerchandiseContext;
using Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // builder.HasOne(t => t.MerchandiseList).WithOne().HasForeignKey<OrderMerchandise>("OrderForeignKey");
            builder.HasMany(t => t.MerchandiseList).WithOne().OnDelete(DeleteBehavior.Cascade);
            // builder.HasMany(t => t.ExchangedMerchandise).WithOne().OnDelete(DeleteBehavior.Cascade);
            // builder.HasMany(t => t.CreditCardList).WithOne().OnDelete(DeleteBehavior.Cascade);
            // builder.HasOne(t => t.DeliveryAddress).WithOne().HasForeignKey<Address>("OrderForeignKey");
            // builder.HasOne(t => t.DeliveryAddress).WithOne().OnDelete(DeleteBehavior.Cascade);
            // builder.HasOne(t => t.BillingAddress).WithOne().HasForeignKey<Address>("OrderForeignKey");
            // builder.HasOne(t => t.BillingAddress).WithOne().OnDelete(DeleteBehavior.Cascade);
            // builder.Property(o => o.LastUpdate).HasColumnType("timestamp()");
        }
    }
}