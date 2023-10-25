using MediatR;

namespace Ticket4me.Application.UseCases.v1.Category.DeleteCategory;
public interface IDeleteCategory : IRequestHandler<DeleteCategoryInput> { }
