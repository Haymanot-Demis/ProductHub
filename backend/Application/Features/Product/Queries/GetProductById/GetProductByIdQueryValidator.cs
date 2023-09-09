using FluentValidation;

namespace Application.Features.Product.Queries.GetProductById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(u => u.ProdId)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");
    }
}