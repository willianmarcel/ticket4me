namespace Ticket4me.Domain.Exceptions.v1;
public class EntityValidationException : Exception
{
    public EntityValidationException(string? message) : base(message)
    {
    }
}
