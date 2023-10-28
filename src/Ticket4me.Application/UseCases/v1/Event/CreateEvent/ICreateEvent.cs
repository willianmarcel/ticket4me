using MediatR;
using Ticket4me.Application.UseCases.v1.Event.Common;

namespace Ticket4me.Application.UseCases.v1.Event.CreateEvent;
public interface ICreateEvent : IRequestHandler<CreateEventInput, EventModelOutput> { }
