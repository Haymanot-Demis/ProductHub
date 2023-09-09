using Application.Contracts.Persistence;
using Application.DTO.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductResponseDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponseDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var prods = await _productRepository.GetAllAsync();
        return _mapper.Map<List<ProductResponseDto>>(prods);
    }
}