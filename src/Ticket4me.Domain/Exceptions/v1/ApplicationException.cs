namespace Ticket4me.Domain.Exceptions.v1;
public abstract class ApplicationException : Exception
{
    protected ApplicationException(string? message) : base(message)
    { }
}