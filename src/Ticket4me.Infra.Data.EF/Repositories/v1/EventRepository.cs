using Microsoft.EntityFrameworkCore;
using Ticket4me.Domain.Contracts.v1;
using Ticket4me.Domain.Entities;
using Ticket4me.Domain.Exceptions.v1;
using Ticket4me.Domain.Searchable;
using Ticket4me.Infra.Data.EF.Context.v1;

namespace Ticket4me.Infra.Data.EF.Repositories.v1;
public class EventRepository : IEventRepository
{
    private readonly Ticket4meDbContext _context;
    private DbSet<Event> _events => _context.Set<Event>();

    public EventRepository(Ticket4meDbContext context)
        => _context = context;

    public async Task InsertAsync(Event aggregate, CancellationToken cancellationToken)
    => await _events.AddAsync(aggregate, cancellationToken);

    public async Task<Event> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var Event = await _events.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        NotFoundException.ThrowIfNull(Event, $"Event '{id}' not found.");
        return Event!;
    }

    public Task UpdateAsync(Event aggregate, CancellationToken _)
        => Task.FromResult(_events.Update(aggregate));

    public Task DeleteAsync(Event aggregate, CancellationToken _)
        => Task.FromResult(_events.Remove(aggregate));

    public async Task<SearchOutput<Event>> Search(SearchInput input, CancellationToken cancellationToken)
    {
        var toSkip = (input.Page - 1) * input.PerPage;
        var query = _events.AsNoTracking();
        query = AddOrderToQuery(query, input.OrderBy, input.Order);
        if (!string.IsNullOrWhiteSpace(input.Search))
            query = query.Where(x => x.Name.Contains(input.Search));
        var total = await query.CountAsync();
        var items = await query
            .Skip(toSkip)
            .Take(input.PerPage)
            .ToListAsync();
        return new(input.Page, input.PerPage, total, items);
    }

    private IQueryable<Event> AddOrderToQuery(IQueryable<Event> query, string orderProperty, SearchOrder order)
    {
        var orderedQuery = (orderProperty.ToLower(), order) switch
        {
            ("name", SearchOrder.Asc) => query.OrderBy(x => x.Name)
                .ThenBy(x => x.Id),
            ("name", SearchOrder.Desc) => query.OrderByDescending(x => x.Name)
                .ThenByDescending(x => x.Id),
            ("id", SearchOrder.Asc) => query.OrderBy(x => x.Id),
            ("id", SearchOrder.Desc) => query.OrderByDescending(x => x.Id),
            ("createdat", SearchOrder.Asc) => query.OrderBy(x => x.CreatedAt),
            ("createdat", SearchOrder.Desc) => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
        };
        return orderedQuery;
    }
}
