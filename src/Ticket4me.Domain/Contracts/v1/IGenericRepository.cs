using Ticket4me.Domain.Entities;

namespace Ticket4me.Domain.Contracts.v1;
public interface IGenericRepository<TAggregate> : IRepository
    where TAggregate : AggregateRoot
{
    public Task InsertAsync(TAggregate aggregate, CancellationToken cancellationToken);
    public Task<TAggregate> GetAsync(Guid id, CancellationToken cancellationToken);
    public Task DeleteAsync(TAggregate aggregate, CancellationToken cancellationToken);
    public Task UpdateAsync(TAggregate aggregate, CancellationToken cancellationToken);
}
