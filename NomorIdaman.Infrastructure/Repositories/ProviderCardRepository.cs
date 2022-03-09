using Microsoft.EntityFrameworkCore;
using NomorIdaman.Application.Common.Models.Enums;
using NomorIdaman.Application.Features.ProviderCard.Queries.GetList;
using NomorIdaman.Application.Interfaces.Repositories;
using NomorIdaman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Infrastructure.Repositories {
    public class ProviderCardRepository : GenericRepository<ProviderCardRepository>, IProviderCardRepository {

        public AppDbContext AppDbContext {
            get { return Context as AppDbContext; }
        }

        public ProviderCardRepository(DbContext context) : base(context) {
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

        public async Task<(int totalCount, IEnumerable<ProviderCard>)> GetListAsNoTrackingAsync(ProviderGetListQuery query) {
            IQueryable<ProviderCard> providers = AppDbContext.ProviderCards.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(query.Keyword)) {
                providers = providers.Where(e => e.Name.Contains(query.Keyword));
            }

            if (query.IsActive.HasValue) {
                providers = providers.Where(e => e.IsActive == query.IsActive.Value);
            }

            if (query.SortBy == SortBy.Asc) {
                providers = providers.OrderBy(e => e.Name);
            } else {
                providers = providers.OrderByDescending(e => e.Name);
            }

            int totalCount = await providers.AsNoTracking().CountAsync();

            var list = await providers
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .AsNoTracking()
                .ToListAsync();
            return (totalCount, list);
        }
    }
}
