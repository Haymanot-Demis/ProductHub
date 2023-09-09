using Application.Features.Users.Commands.UpdateUser;
using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        When(dto => !string.IsNullOrEmpty(dto.CreateProdDto.Name), () =>
        {
            RuleFor(x => x.CreateProdDto.Name).MinimumLength(10).WithMessage("{PropertyName} must either empty or length of greater than 10");
        });
        
        When(dto => dto.CreateProdDto.Price != 0, () =>
        {
            RuleFor(x => x.CreateProdDto.Price).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than 0");
        });
    }
}