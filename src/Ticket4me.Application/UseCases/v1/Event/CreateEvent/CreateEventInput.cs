using MediatR;
using Ticket4me.Application.UseCases.v1.Event.Common;

namespace Ticket4me.Application.UseCases.v1.Event.CreateEvent;
public class CreateEventInput : IRequest<EventModelOutput>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime Date { get; set; }
    public string Start { get; set; }
    public string Finish { get; set; }
    public bool IsActive { get; set; }

    public CreateEventInput(string name, string description, string image, DateTime date, string start, string finish, bool isActive)
    {
        Name = name;
        Description = description;
        Image = image;
        Date = date;
        Start = start;
        Finish = finish;
        IsActive = isActive;
    }
}
