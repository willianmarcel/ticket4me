using Ticket4me.Application.UseCases.v1.Category.Common.v1;
using Ticket4me.Domain.Contracts.v1;
using DomainEntity = Ticket4me.Domain.Entities;

namespace Ticket4me.Application.UseCases.v1.Category.CreateCategory;
public class CreateCategory : ICreateCategory
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategory(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryModelOutput> Handle(CreateCategoryInput input, CancellationToken cancellationToken)
    {
        var category = new DomainEntity.Category(
            input.Name,
            input.Description,
            input.IsActive,
            DateTime.UtcNow
        );

        await _categoryRepository.InsertAsync(category, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return CategoryModelOutput.FromCategory(category);
    }
}
