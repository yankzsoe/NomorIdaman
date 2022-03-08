using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NomorIdaman.Domain.Entities;

namespace NomorIdaman.Infrastructure.Configurations {
    public class ProviderCardConfiguration : IEntityTypeConfiguration<ProviderCard> {
        public void Configure(EntityTypeBuilder<ProviderCard> builder) {
            //  MAPING TO TABLE CLASS
            builder.ToTable(nameof(ProviderCard));

            //  INDEX
            builder.HasIndex(x => x.Name);
        }
    }
}
