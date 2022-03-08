using NomorIdaman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomorIdaman.Application.Interfaces.Repositories {
    public interface IProviderCardRepository : IGenericRepository<ProviderCard> {
        Task<ProviderCard> GetByIdAsNoTrackingAsync(int id);
        Task<IEnumerable<ProviderCard>> GetAllAsNoTrackingAsync();
    }
}
