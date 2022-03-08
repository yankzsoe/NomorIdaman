using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NomorIdaman.Domain.Entities;

namespace NomorIdaman.Infrastructure.Configurations {
    public class SIMCardConfiguration : IEntityTypeConfiguration<SIMCard> {
        public void Configure(EntityTypeBuilder<SIMCard> builder) {
            //  MAPING TO TABLE CLASS
            builder.ToTable(nameof(SIMCard));

            //  INDEX
            builder.HasIndex(x => x.CardNumber);
        }
    }
}
