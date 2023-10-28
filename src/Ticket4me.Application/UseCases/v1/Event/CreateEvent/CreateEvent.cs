using Ticket4me.Application.UseCases.v1.Event.Common;
using Ticket4me.Domain.Contracts.v1;
using DomainEntity = Ticket4me.Domain.Entities;

namespace Ticket4me.Application.UseCases.v1.Event.CreateEvent;
public class CreateEvent : ICreateEvent
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEvent(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EventModelOutput> Handle(CreateEventInput input, CancellationToken cancellationToken)
    {
        var @event = new DomainEntity.Event(
        input.Name,
            input.Description,
            input.Image,
            input.Date,
            input.Start,
            input.Finish,
            input.IsActive,
            DateTime.UtcNow
        );

        await _eventRepository.InsertAsync(@event, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return EventModelOutput.FromEvent(@event);
    }
}
