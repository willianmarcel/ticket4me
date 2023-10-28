using DomainEntity = Ticket4me.Domain.Entities;

namespace Ticket4me.Application.UseCases.v1.Event.Common;
public class EventModelOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime Date { get; set; }
    public string Start { get; set; }
    public string Finish { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }

    public EventModelOutput(Guid id, string name, string description, string image, DateTime date, string start, string finish, bool isActive, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Image = image;
        Date = date;
        Start = start;
        Finish = finish;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public static EventModelOutput FromEvent(DomainEntity.Event @event)
    => new(
        @event.Id,
        @event.Name,
        @event.Description,
        @event.Image,
        @event.Date,
        @event.Start,
        @event.Finish,
        @event.IsActive,
        @event.CreatedAt
    );
}
