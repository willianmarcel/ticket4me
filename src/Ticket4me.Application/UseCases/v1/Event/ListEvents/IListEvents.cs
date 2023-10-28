using MediatR;
using Ticket4me.Application.UseCases.v1.Category.ListEvents;

namespace Ticket4me.Application.UseCases.v1.Event.ListEvents;
public interface IListEvents : IRequestHandler<ListEventsInput, ListEventsOutput> { }
