using Ticket4me.Domain.Validation;

namespace Ticket4me.Domain.Entities;
public class Event : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public DateTime Date { get; private set; }
    public string Start { get; private set; }
    public string Finish { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Event(string name, string description, string image, DateTime date, string start, string finish, bool isActive, DateTime createdAt)
        : base()
    {
        Name = name;
        Description = description;
        Image = image;
        Date = date;
        Start = start;
        Finish = finish;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public void Activate()
    {
        IsActive = true;
        Validate();
    }

    public void Deactivate()
    {
        IsActive = false;
        Validate();
    }

    public void Update(string name, string? description = null)
    {
        Name = name;
        Description = description ?? Description;

        Validate();
    }

    private void Validate()
    {
        DomainValidation.NotNullOrEmpty(Name, nameof(Name));
        DomainValidation.MinLength(Name, 3, nameof(Name));
        DomainValidation.MaxLength(Name, 255, nameof(Name));

        DomainValidation.NotNull(Description, nameof(Description));
        DomainValidation.MaxLength(Description, 10_000, nameof(Description));

        DomainValidation.NotNull(Date, nameof(Date));
    }
}
