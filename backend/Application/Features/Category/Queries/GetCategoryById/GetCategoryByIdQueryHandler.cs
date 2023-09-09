using Application.Contracts.Persistence;
using Application.DTO.Category;
using Application.DTO.Product;
using Application.Features.Product.Queries.GetProductById;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper; 
    
    public GetCategoryByIdQueryHandler(IProductRepository productRepository ,IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<CategoryResponseDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new GetCategoryByIdQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors);
        
        // handler
        var prod = await _productRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CategoryResponseDto>(prod);
    }
}