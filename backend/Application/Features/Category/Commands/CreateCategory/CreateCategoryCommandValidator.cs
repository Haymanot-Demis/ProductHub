using FluentValidation;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(product => product.CreateCategoryDto.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min: 2, max: 20).WithMessage("{PropertyName} must be between 2 and 20 characters.")
            .Matches("^[a-zA-Z0-9_]+$")
            .WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");

        When(dto => !string.IsNullOrEmpty(dto.CreateCategoryDto.Description),
            () => { RuleFor(prod => prod.CreateCategoryDto.Description).MinimumLength(3); }
        );
    }
}