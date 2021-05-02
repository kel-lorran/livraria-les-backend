using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class StockMerchandiseMap : IEntityTypeConfiguration<StockMerchandise>
    {
        public void Configure(EntityTypeBuilder<StockMerchandise> builder)
        {
            builder.HasOne(m => m.Book);
        }
    }
}