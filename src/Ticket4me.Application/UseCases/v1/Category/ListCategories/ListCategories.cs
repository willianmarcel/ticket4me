using Ticket4me.Application.UseCases.v1.Category.Common.v1;
using Ticket4me.Domain.Contracts.v1;

namespace Ticket4me.Application.UseCases.v1.Category.ListCategories;
public class ListCategories : IListCategories
{
    private readonly ICategoryRepository _categoryRepository;

    public ListCategories(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;

    public async Task<ListCategoriesOutput> Handle(ListCategoriesInput request, CancellationToken cancellationToken)
    {
        var searchOutput = await _categoryRepository.Search(
            new(
                request.Page,
                request.PerPage,
                request.Search,
                request.Sort,
                request.Dir
            ),
            cancellationToken
        );

        return new ListCategoriesOutput(
            searchOutput.CurrentPage,
            searchOutput.PerPage,
            searchOutput.Total,
            searchOutput.Items
                .Select(CategoryModelOutput.FromCategory)
                .ToList()
        );
    }
}
