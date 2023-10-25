using MediatR;

namespace Ticket4me.Application.UseCases.v1.Category.DeleteCategory;
public class DeleteCategoryInput : IRequest
{
    public Guid Id { get; set; }
    public DeleteCategoryInput(Guid id)
        => Id = id;
}
