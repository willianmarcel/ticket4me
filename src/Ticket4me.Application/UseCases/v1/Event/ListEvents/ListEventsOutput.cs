using Ticket4me.Application.Common.v1;
using Ticket4me.Application.UseCases.v1.Event.Common;

namespace Ticket4me.Application.UseCases.v1.Event.ListEvents;
public class ListEventsOutput : PaginatedListOutput<EventModelOutput>
{
    public ListEventsOutput(
        int page,
        int perPage,
        int total,
        IReadOnlyList<EventModelOutput> items)
        : base(page, perPage, total, items)
    {
    }
}
