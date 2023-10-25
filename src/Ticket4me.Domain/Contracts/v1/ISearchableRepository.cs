using Ticket4me.Domain.Entities;
using Ticket4me.Domain.Searchable;

namespace Ticket4me.Domain.Contracts.v1;
public interface ISearchableRepository<Taggregate>
    where Taggregate : AggregateRoot
{
    Task<SearchOutput<Taggregate>> Search(
        SearchInput input,
        CancellationToken cancellationToken
    );
}
