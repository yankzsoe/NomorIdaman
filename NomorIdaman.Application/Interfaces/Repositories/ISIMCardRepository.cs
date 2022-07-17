using NomorIdaman.Application.Features.SIMCard.Queries.GetList;
using NomorIdaman.Application.Features.SIMCard.Queries.GetListSummary;
using NomorIdaman.Application.Features.SIMCard.Queries.GetListUnion;
using NomorIdaman.Domain.Common;
using NomorIdaman.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Interfaces.Repositories {
    public interface ISIMCardRepository : IGenericRepository<SIMCard> {
        Task<SIMCard> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<SIMCard>> GetAllAsNoTrackingAsync();
        Task<(int count, IEnumerable<SIMCard>)> GetListAsNotrackingAsync(SIMCardGetListQuery query);
        Task<(int count, IEnumerable<SIMCard>)> GetListUnionAsNotrackingAsync(SIMCardGetListUnionQuery query);
        Task<(int count, IEnumerable<SIMCardSummary>)> GetListSIMCardSummary(SIMCardGetListSummaryQuery query);
    }
}
