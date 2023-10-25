using MediatR;
using Ticket4me.Domain.Contracts.v1;

namespace Ticket4me.Application.UseCases.v1.Category.DeleteCategory;
public class DeleteCategory : IDeleteCategory
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        => (_categoryRepository, _unitOfWork) = (categoryRepository, unitOfWork);

    public async Task<Unit> Handle(DeleteCategoryInput request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id, cancellationToken);
        await _categoryRepository.DeleteAsync(category, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}
