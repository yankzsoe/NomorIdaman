using NomorIdaman.Application.Features.SIMCard.Queries.GetList;
using NomorIdaman.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Interfaces.Repositories {
    public interface ISIMCardRepository : IGenericRepository<SIMCard> {
        Task<SIMCard> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<SIMCard>> GetAllAsNoTrackingAsync();
        Task<(int count, IEnumerable<SIMCard>)> GetListAsNotrackingAsync(SIMCardGetListQuery query);
    }
}
