using Domain.MerchandiseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class MerchandiseMap : IEntityTypeConfiguration<Merchandise>
    {
        public void Configure(EntityTypeBuilder<Merchandise> builder)
        {
            builder.HasOne(m => m.Book);
        }
    }
}