using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class OrderMerchandiseMap : IEntityTypeConfiguration<OrderMerchandise>
    {
        public void Configure(EntityTypeBuilder<OrderMerchandise> builder)
        {
            builder.HasOne(m => m.Book);
        }
    }
}