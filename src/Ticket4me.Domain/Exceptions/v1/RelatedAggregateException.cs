namespace Ticket4me.Domain.Exceptions.v1;
public class RelatedAggregateException : ApplicationException
{
    public RelatedAggregateException(string? message) : base(message)
    { }
}
