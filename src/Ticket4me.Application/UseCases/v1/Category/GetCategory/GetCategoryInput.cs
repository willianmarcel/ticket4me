using MediatR;
using Ticket4me.Application.UseCases.v1.Category.Common.v1;

namespace Ticket4me.Application.UseCases.v1.Category.GetCategory;
public class GetCategoryInput : IRequest<CategoryModelOutput>
{
    public Guid Id { get; set; }
    public GetCategoryInput(Guid id)
        => Id = id;
}
