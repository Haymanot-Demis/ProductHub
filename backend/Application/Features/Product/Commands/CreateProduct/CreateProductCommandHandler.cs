using Application.Contracts.Persistence;
using Application.DTO.Product;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }
    public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        // validating the incoming request
        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var category = await _categoryRepository.GetByIdAsync(request.CreateProductDto.CategoryId);
        
        if (category == null)
        {
            throw new Exception($"Category with id {request.CreateProductDto.CategoryId} not found");
        }
        
        // mapping the incoming request to the user entity
        var productEntity = _mapper.Map<ProductEntity>(request.CreateProductDto);
        productEntity.Category = category;
        
        // adding the user to the database
        var newUser = await _productRepository.CreateAsync(productEntity);
        return _mapper.Map<ProductResponseDto>(newUser);
    }
}