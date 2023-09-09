using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Product.Commands.DeleteUser;
using Application.Features.Users.Commands.DeleteUser;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new DeleteProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult.Errors);
        }
        // check if post exists
        var user = await _productRepository.GetByIdAsync(request.ProdId);
        if (user == null)
        {
            throw new NotFoundException($"Product with id {request.ProdId} not found");
        }
        await _productRepository.DeleteAsync(user);
        return Unit.Value;
    }
}