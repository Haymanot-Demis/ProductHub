using Application.Features.Product.Commands.DeleteUser;
using Application.Features.Users.Commands.DeleteUser;
using FluentValidation;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProdId).NotEmpty().WithMessage("{PropertyName} is required").GreaterThan(0).WithMessage("{PropertyName} can't be less than 1");
    }
}