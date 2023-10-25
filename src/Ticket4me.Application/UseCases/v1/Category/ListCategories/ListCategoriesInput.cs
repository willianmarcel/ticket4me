using MediatR;
using Ticket4me.Application.Common.v1;
using Ticket4me.Domain.Searchable;

namespace Ticket4me.Application.UseCases.v1.Category.ListCategories;
public class ListCategoriesInput : PaginatedListInput, IRequest<ListCategoriesOutput>
{
    public ListCategoriesInput(
        int page = 1,
        int perPage = 15,
        string search = "",
        string sort = "",
        SearchOrder dir = SearchOrder.Asc
    ) : base(page, perPage, search, sort, dir)
    { }

    public ListCategoriesInput()
        : base(1, 15, "", "", SearchOrder.Asc)
    { }
}
