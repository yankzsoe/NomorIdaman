using NomorIdaman.Application.Interfaces;
using NomorIdaman.Application.Interfaces.Repositories;
using NomorIdaman.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Infrastructure {
    public class UnitOfWork : IUnitOfWork {

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) {
            _context = context;

            Shops = new ShopRepository(context);
            ProviderCards = new ProviderCardRepository(context);
            SIMCards = new SIMCardRepository(context);
        }

        public IShopRepository Shops { get; private set; }

        public IProviderCardRepository ProviderCards { get; private set; }

        public ISIMCardRepository SIMCards { get; private set; }

        public async Task<int> CompleteAsync() {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync() {
            await _context.DisposeAsync();
        }
    }
}
