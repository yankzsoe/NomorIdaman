using Microsoft.EntityFrameworkCore;
using NomorIdaman.Application.Common.Models.Enums;
using NomorIdaman.Application.Features.SIMCard.GetList;
using NomorIdaman.Application.Features.SIMCard.Queries.GetList;
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

        public async Task<(int count, IEnumerable<SIMCard>)> GetListAsNotrackingAsync(SIMCardGetListQuery query) {
            IQueryable<SIMCard> simCards = AppDbContext.SIMCards
                .Include(e => e.Shop)
                .Include(e => e.ProviderCard)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(query.Keyword)) {
                simCards = simCards.AsNoTracking().Where(e => e.CardNumber.Contains(query.Keyword)
                || e.Shop.Code.Contains(query.Keyword)
                || e.ProviderCard.Name.Contains(query.Keyword));
            }

            if (query.IsActive.HasValue) {
                simCards = simCards.Where(e => e.IsActive == query.IsActive.Value);
            }

            if (query.OrderBy == SIMCardOrderBy.Provider) {
                if (query.SortBy == SortBy.Asc) {
                    simCards = simCards.OrderBy(e => e.ProviderCard.Name);
                } else {
                    simCards = simCards.OrderByDescending(e => e.ProviderCard.Name);
                }
            } else {
                if (query.SortBy == SortBy.Asc) {
                    simCards = simCards.OrderBy(e => e.Shop.Code);
                } else {
                    simCards = simCards.OrderByDescending(e => e.Shop.Code);
                }
            }

            int count = await simCards.AsNoTracking().CountAsync();
            var list = await simCards
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return (count, list);
        }
    }
}
