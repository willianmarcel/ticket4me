using Ticket4me.Application.UseCases.v1.Category.Common.v1;
using Ticket4me.Domain.Contracts.v1;

namespace Ticket4me.Application.UseCases.v1.Category.UpdateCategory;
public class UpdateCategory : IUpdateCategory
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _uinitOfWork;

    public UpdateCategory(
        ICategoryRepository categoryRepository,
        IUnitOfWork uinitOfWork)
        => (_categoryRepository, _uinitOfWork)
            = (categoryRepository, uinitOfWork);

    public async Task<CategoryModelOutput> Handle(UpdateCategoryInput request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id, cancellationToken);
        category.Update(request.Name, request.Description);
        if (
            request.IsActive != null &&
            request.IsActive != category.IsActive
        )
            if ((bool)request.IsActive!) category.Activate();
            else category.Deactivate();
        await _categoryRepository.UpdateAsync(category, cancellationToken);
        await _uinitOfWork.CommitAsync(cancellationToken);
        return CategoryModelOutput.FromCategory(category);
    }
}
