using Ticket4me.Domain.Entities;

namespace Ticket4me.Domain.Contracts.v1;
public interface ICategoryRepository : IGenericRepository<Category>, ISearchableRepository<Category>
{
    public Task<IReadOnlyList<Guid>> GetIdsListByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
}
