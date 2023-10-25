using MediatR;

namespace Ticket4me.Application.UseCases.v1.Category.ListCategories;
public interface IListCategories : IRequestHandler<ListCategoriesInput, ListCategoriesOutput> { }
