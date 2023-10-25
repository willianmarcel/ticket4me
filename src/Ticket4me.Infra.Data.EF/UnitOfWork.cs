using Ticket4me.Domain.Contracts.v1;
using Ticket4me.Infra.Data.EF.Context.v1;

namespace Ticket4me.Infra.Data.EF;
public class UnitOfWork : IUnitOfWork
{
    private readonly Ticket4meDbContext _context;

    public UnitOfWork(Ticket4meDbContext context)
        => _context = context;

    public Task CommitAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);

    public Task RollbackAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}