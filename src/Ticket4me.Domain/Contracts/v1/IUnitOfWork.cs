namespace Ticket4me.Domain.Contracts.v1;
public interface IUnitOfWork
{
    public Task CommitAsync(CancellationToken cancellationToken);
    public Task RollbackAsync(CancellationToken cancellationToken);
}
