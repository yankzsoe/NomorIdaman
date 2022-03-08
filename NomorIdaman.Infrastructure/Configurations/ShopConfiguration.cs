using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NomorIdaman.Domain.Entities;

namespace NomorIdaman.Infrastructure.Configurations {
    public class ShopConfiguration : IEntityTypeConfiguration<Shop> {
        public void Configure(EntityTypeBuilder<Shop> builder) {
            //  MAPING TO TABLE CLASS
            builder.ToTable(nameof(Shop));

            //  INDEX
            builder.HasIndex(x => x.Code);
        }
    }
}
