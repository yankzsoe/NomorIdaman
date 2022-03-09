using NomorIdaman.Application.Features.Shop.Queries.GetList;
using NomorIdaman.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Interfaces.Repositories {
    public interface IShopRepository : IGenericRepository<Shop> {
        Task<Shop> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<Shop>> GetAllAsNoTrackingAsync();
        Task<(int count, IEnumerable<Shop> shops)> GetListAsNotrackingAsync(ShopGetListQuery query);
    }
}
