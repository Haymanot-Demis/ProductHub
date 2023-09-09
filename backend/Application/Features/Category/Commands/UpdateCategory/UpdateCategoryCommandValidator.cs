using FluentValidation;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        When(dto => !string.IsNullOrEmpty(dto.CategoryDto.Name),
        () =>
        {
            RuleFor(product => product.CategoryDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(min: 2, max: 20).WithMessage("{PropertyName} must be between 2 and 20 characters.")
                .Matches("^[a-zA-Z0-9_]+$")
                .WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");
        }
        );

        When(dto => !string.IsNullOrEmpty(dto.CategoryDto.Description),
            () => { RuleFor(prod => prod.CategoryDto.Description).MinimumLength(3); }
        );
    }
}