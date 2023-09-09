using FluentValidation;

namespace Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");
    }
}