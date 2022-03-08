using Microsoft.EntityFrameworkCore;
using NomorIdaman.Application.Interfaces.Repositories;
using NomorIdaman.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NomorIdaman.Infrastructure.Repositories {
    public class ShopRepository : GenericRepository<ShopRepository>, IShopRepository {
        public AppDbContext AppDbContext {
            get { return Context as AppDbContext; }
        }

        public ShopRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Shop entity) {
            await AppDbContext.Shops.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Shop> entities) {
            await AppDbContext.Shops.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<Shop>> GetAllAsNoTrackingAsync() {
            return await AppDbContext.Shops
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Shop> GetByIdAsNoTrackingAsync(int id) {
            return await AppDbContext.Shops
                .AsNoTracking()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Remove(Shop entity) {
            AppDbContext.Shops.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Shop> entities) {
            AppDbContext.Shops.RemoveRange(entities);
        }

        async Task<Shop> IGenericRepository<Shop>.GetAsync(int id) {
            return await AppDbContext.Shops.FindAsync(id);
        }
    }
}
