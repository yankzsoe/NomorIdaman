using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NomorIdaman.Domain.Common;
using NomorIdaman.Domain.Entities;

namespace NomorIdaman.Infrastructure.Configurations {
    public class SIMCardSummaryConfiguration : IEntityTypeConfiguration<SIMCardSummary> {
        public void Configure(EntityTypeBuilder<SIMCardSummary> builder) {
            builder.HasNoKey();
            builder.ToView("SIMCardSummary");
        }
    }
}
