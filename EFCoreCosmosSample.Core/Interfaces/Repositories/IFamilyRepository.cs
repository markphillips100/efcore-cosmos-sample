using EFCoreCosmosSample.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreCosmosSample.Core.Interfaces.Repositories
{
    public interface IFamilyRepository
    {
        Task<Family> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Family>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<Family> AddAsync(Family entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Family entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Family entity, CancellationToken cancellationToken = default);
    }
}
