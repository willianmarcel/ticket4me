using FluentValidation;

namespace Ticket4me.Application.UseCases.v1.Category.GetCategory;
public class GetCategoryInputValidator : AbstractValidator<GetCategoryInput>
{
    public GetCategoryInputValidator()
        => RuleFor(x => x.Id).NotEmpty();
}
