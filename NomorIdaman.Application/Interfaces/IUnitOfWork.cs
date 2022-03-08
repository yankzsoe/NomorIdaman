using NomorIdaman.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Interfaces {
    public interface IUnitOfWork : IAsyncDisposable {
        IShopRepository Shops { get; }
        IProviderCardRepository ProviderCards { get; }
        ISIMCardRepository SIMCards { get; }

        Task<int> CompleteAsync();
    }
}
