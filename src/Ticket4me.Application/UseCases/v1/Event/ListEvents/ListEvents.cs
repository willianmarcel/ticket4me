using Ticket4me.Application.UseCases.v1.Category.ListEvents;
using Ticket4me.Application.UseCases.v1.Event.Common;
using Ticket4me.Domain.Contracts.v1;

namespace Ticket4me.Application.UseCases.v1.Event.ListEvents;
public class ListEvents : IListEvents
{
    private readonly IEventRepository _eventRepository;

    public ListEvents(IEventRepository eventRepository)
        => _eventRepository = eventRepository;

    public async Task<ListEventsOutput> Handle(ListEventsInput request, CancellationToken cancellationToken)
    {
        var searchOutput = await _eventRepository.Search(
            new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                request.Dir
            ),
            cancellationToken
        );

        return new ListEventsOutput(
            searchOutput.CurrentPage,
            searchOutput.PerPage,
            searchOutput.Total,
            searchOutput.Items
                .Select(EventModelOutput.FromEvent)
                .ToList()
        );
    }
}
