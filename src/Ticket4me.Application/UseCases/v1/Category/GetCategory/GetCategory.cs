using Ticket4me.Application.UseCases.v1.Category.Common.v1;
using Ticket4me.Domain.Contracts.v1;

namespace Ticket4me.Application.UseCases.v1.Category.GetCategory;
public class GetCategory : IGetCategory
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategory(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;

    public async Task<CategoryModelOutput> Handle(GetCategoryInput request, CancellationToken cancellationToken
    )
    {
        var category = await _categoryRepository.GetAsync(request.Id, cancellationToken);
        return CategoryModelOutput.FromCategory(category);
    }
}
