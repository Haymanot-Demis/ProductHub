using FluentValidation;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.CreateProductDto.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(min: 2, max: 20).WithMessage("{PropertyName} must be between 2 and 20 characters.")
            .Matches("^[a-zA-Z]+$")
            .WithMessage("{PropertyName} must contain only alphabet characters and underscores.");

        When(dto => !string.IsNullOrEmpty(dto.CreateProductDto.Description),
            () => { RuleFor(prod => prod.CreateProductDto.Description).MinimumLength(3); }
        );
    }
}