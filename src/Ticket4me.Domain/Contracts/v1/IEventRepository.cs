using Ticket4me.Domain.Entities;

namespace Ticket4me.Domain.Contracts.v1;
public interface IEventRepository : IGenericRepository<Event>, ISearchableRepository<Event>
{
}
