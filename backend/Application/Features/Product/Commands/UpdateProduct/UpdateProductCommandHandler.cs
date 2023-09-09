using Application.Contracts.Persistence;
using Application.DTO.Product;
using Application.DTO.User;
using Application.Exceptions;
using Application.Features.Users.Commands.UpdateUser;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var product = await _productRepository.GetByIdAsync(request.ProdId);
        if (product == null)
        {
            throw new NotFoundException($"Product with id {request.ProdId} doesn't exist");
        }
        
        _mapper.Map(request.CreateProdDto, product);
        await _productRepository.UpdateAsync(product);
        return _mapper.Map<ProductResponseDto>(product);
    }
}