using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NomorIdaman.Domain.Common;
using NomorIdaman.Domain.Entities;
using NomorIdaman.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NomorIdaman.Infrastructure {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {

        }

        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ProviderCard> ProviderCards { get; set; }
        public virtual DbSet<SIMCard> SIMCards { get; set; }
        public virtual DbSet<SIMCardSummary> SIMCardSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderCardConfiguration());
            modelBuilder.ApplyConfiguration(new SIMCardConfiguration());
            modelBuilder.ApplyConfiguration(new SIMCardSummaryConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            //foreach (EntityEntry<AuditEntity> entry in ChangeTracker.Entries<AuditEntity>()) {
            //    switch (entry.State) {
            //        case EntityState.Added:
            //            entry.Entity.CreatedDate = _dateTime.Now;
            //            if (string.IsNullOrEmpty(entry.Entity.CreatedBy)) {
            //                entry.Entity.CreatedBy = _currentUser.UserName;
            //            }
            //            break;

            //        case EntityState.Modified:
            //            entry.Entity.UpdatedDate = _dateTime.Now;
            //            if (string.IsNullOrEmpty(entry.Entity.UpdatedBy)) {
            //                entry.Entity.UpdatedBy = _currentUser.UserName;
            //            }
            //            break;
            //    }
            //}

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
