using Microsoft.EntityFrameworkCore;
using NomorIdaman.Application.Interfaces.Repositories;
using NomorIdaman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Infrastructure.Repositories {
    public class ProviderRepository : GenericRepository<ProviderRepository>, IProviderCardRepository {

        public AppDbContext AppDbContext {
            get { return Context as AppDbContext; }
        }

        public ProviderRepository(DbContext context) : base(context) {
        }

        public async Task AddAsync(ProviderCard entity) {
            await AppDbContext.ProviderCards.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<ProviderCard> entities) {
            await AppDbContext.ProviderCards.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<ProviderCard>> GetAllAsNoTrackingAsync() {
            return await AppDbContext.ProviderCards
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProviderCard> GetByIdAsNoTrackingAsync(int id) {
            return await AppDbContext.ProviderCards
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Remove(ProviderCard entity) {
            AppDbContext.ProviderCards.Remove(entity);
        }

        public void RemoveRange(IEnumerable<ProviderCard> entities) {
            AppDbContext.ProviderCards.RemoveRange(entities);
        }

        async Task<ProviderCard> IGenericRepository<ProviderCard>.GetAsync(int id) {
            return await AppDbContext.ProviderCards.FindAsync(id);
        }
    }
}
