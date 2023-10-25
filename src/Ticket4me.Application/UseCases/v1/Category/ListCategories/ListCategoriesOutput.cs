using Ticket4me.Application.Common.v1;
using Ticket4me.Application.UseCases.v1.Category.Common.v1;

namespace Ticket4me.Application.UseCases.v1.Category.ListCategories;
public class ListCategoriesOutput : PaginatedListOutput<CategoryModelOutput>
{
    public ListCategoriesOutput(
        int page,
        int perPage,
        int total,
        IReadOnlyList<CategoryModelOutput> items)
        : base(page, perPage, total, items)
    {
    }
}
