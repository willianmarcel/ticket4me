using Microsoft.EntityFrameworkCore;
using Ticket4me.Domain.Contracts.v1;
using Ticket4me.Domain.Entities;
using Ticket4me.Domain.Exceptions.v1;
using Ticket4me.Domain.Searchable;
using Ticket4me.Infra.Data.EF.Context.v1;

namespace Ticket4me.Infra.Data.EF.Repositories.v1;
public class CategoryRepository : ICategoryRepository
{
    private readonly Ticket4meDbContext _context;
    private DbSet<Category> _categories => _context.Set<Category>();

    public CategoryRepository(Ticket4meDbContext context) 
        => _context = context;

    public async Task InsertAsync(Category aggregate, CancellationToken cancellationToken)
        => await _categories.AddAsync(aggregate, cancellationToken);

    public async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        NotFoundException.ThrowIfNull(category, $"Category '{id}' not found.");
        return category!;
    }

    public Task UpdateAsync(Category aggregate, CancellationToken _)
        => Task.FromResult(_categories.Update(aggregate));

    public Task DeleteAsync(Category aggregate, CancellationToken _)
        => Task.FromResult(_categories.Remove(aggregate));

    public async Task<SearchOutput<Category>> Search(SearchInput input, CancellationToken cancellationToken)
    {
        var toSkip = (input.Page - 1) * input.PerPage;
        var query = _categories.AsNoTracking();
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

    private IQueryable<Category> AddOrderToQuery(IQueryable<Category> query, string orderProperty, SearchOrder order)
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

    public Task<IReadOnlyList<Guid>> GetIdsListByIdsAsync(List<Guid> ids, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
