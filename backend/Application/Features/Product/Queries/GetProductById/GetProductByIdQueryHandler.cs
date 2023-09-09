using Application.Contracts.Persistence;
using Application.DTO.Product;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper; 
    
    public GetProductByIdQueryHandler(IProductRepository productRepository ,IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new GetProductByIdQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors);
        
        // handler
        var prod = await _productRepository.GetByIdAsync(request.ProdId);
        return _mapper.Map<ProductResponseDto>(prod);
    }
}