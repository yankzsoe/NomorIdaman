using Microsoft.EntityFrameworkCore;
using NomorIdaman.Application.Common.Models.Enums;
using NomorIdaman.Application.Features.SIMCard.GetList;
using NomorIdaman.Application.Features.SIMCard.Queries.GetList;
using NomorIdaman.Application.Features.SIMCard.Queries.GetListSummary;
using NomorIdaman.Application.Features.SIMCard.Queries.GetListUnion;
using NomorIdaman.Application.Interfaces.Repositories;
using NomorIdaman.Domain.Common;
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

            if (query.ShopId > 0) {
                simCards = simCards.Where(e => e.ShopId == query.ShopId);
            }

            if (query.ProviderId > 0) {
                simCards = simCards.Where(e => e.ProviderCardId == query.ProviderId);
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

        public async Task<(int count, IEnumerable<SIMCard>)> GetListUnionAsNotrackingAsync(SIMCardGetListUnionQuery query) {
            IQueryable<SIMCard> simCards = AppDbContext.SIMCards
                .Include(e => e.Shop)
                .Include(e => e.ProviderCard)
                .Where(e => e.ProviderCard.Name.ToLower() == "simpati")
                .Take(10)
                .Union(AppDbContext.SIMCards
                    .Include(e => e.Shop)
                    .Include(e => e.ProviderCard)
                    .Where(e => e.ProviderCard.Name == "xl")
                    .Take(1))
                .Union(AppDbContext.SIMCards
                    .Include(e => e.Shop)
                    .Include(e => e.ProviderCard)
                    .Where(e => e.ProviderCard.Name == "as")
                    .Take(10))
                .Union(AppDbContext.SIMCards
                    .Include(e => e.Shop)
                    .Include(e => e.ProviderCard)
                    .Where(e => e.ProviderCard.Name == "halo")
                    .Take(10))
                .Union(AppDbContext.SIMCards
                    .Include(e => e.Shop)
                    .Include(e => e.ProviderCard)
                    .Where(e => e.ProviderCard.Name == "im3")
                    .Take(10))
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(query.Keyword)) {
                simCards = simCards.AsNoTracking().Where(e => e.CardNumber.Contains(query.Keyword)
                || e.Shop.Code.Contains(query.Keyword)
                || e.ProviderCard.Name.Contains(query.Keyword));
            }

            if (query.IsActive.HasValue) {
                simCards = simCards.Where(e => e.IsActive == query.IsActive.Value);
            }

            if (query.ShopId > 0) {
                simCards = simCards.Where(e => e.ShopId == query.ShopId);
            }

            if (query.ProviderId > 0) {
                simCards = simCards.Where(e => e.ProviderCardId == query.ProviderId);
            }

            simCards = simCards.OrderByDescending(e => e.ProviderCardId);

            int count = await simCards.AsNoTracking().CountAsync();
            var list = await simCards
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .AsNoTracking()
                .ToListAsync();

            return (count, list);
        }

        public async Task<(int count, IEnumerable<SIMCardSummary>)> GetListSIMCardSummary(SIMCardGetListSummaryQuery query) {
            var sql = "SELECT P.Name AS CardName, COUNT(P.Name) Count" +
                      " FROM SIMCard S " +
                      " JOIN ProviderCard P ON S.ProviderCardId = P.Id " +
                      " JOIN Shop SH ON S.ShopId = SH.Id " +
                      " WHERE S.IsActive = 1 " +
                      " GROUP BY P.Name, S.ProviderCardId " +
                      " ORDER BY S.ProviderCardId";
            IQueryable<SIMCardSummary> summaries = AppDbContext.SIMCardSummaries.FromSqlRaw(sql);
            
            var list = await summaries.AsNoTracking().ToListAsync();
            int count = list.Count;
            return (count, list);
        }
    }
}
