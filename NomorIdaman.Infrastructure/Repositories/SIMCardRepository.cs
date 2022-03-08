using Microsoft.EntityFrameworkCore;
using NomorIdaman.Application.Interfaces.Repositories;
using NomorIdaman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Infrastructure.Repositories {
    public class SIMCardRepository : GenericRepository<SIMCardRepository>, ISIMCardRepository {

        public AppDbContext AppDbContext {
            get { return Context as AppDbContext; }
        }

        public SIMCardRepository(DbContext context) : base(context) {
        }

        public async Task AddAsync(SIMCard entity) {
            await AppDbContext.SIMCards.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<SIMCard> entities) {
            await AppDbContext.SIMCards.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<SIMCard>> GetAllAsNoTrackingAsync() {
            return await AppDbContext.SIMCards
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SIMCard> GetByIdAsNoTrackingAsync(int id) {
            return await AppDbContext.SIMCards
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Remove(SIMCard entity) {
            AppDbContext.SIMCards.Remove(entity);
        }

        public void RemoveRange(IEnumerable<SIMCard> entities) {
            AppDbContext.SIMCards.RemoveRange(entities);
        }

        async Task<SIMCard> IGenericRepository<SIMCard>.GetAsync(int id) {
            return await AppDbContext.SIMCards.FindAsync(id);
        }
    }
}
