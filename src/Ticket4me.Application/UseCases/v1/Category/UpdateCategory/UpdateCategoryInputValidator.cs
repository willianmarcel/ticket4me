using FluentValidation;

namespace Ticket4me.Application.UseCases.v1.Category.UpdateCategory;
public class UpdateCategoryInputValidator : AbstractValidator<UpdateCategoryInput>
{
    public UpdateCategoryInputValidator()
        => RuleFor(x => x.Id).NotEmpty();
}
