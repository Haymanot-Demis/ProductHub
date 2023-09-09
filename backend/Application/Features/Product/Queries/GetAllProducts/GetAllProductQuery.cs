using Application.DTO.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductQuery : IRequest<List<ProductResponseDto>>
{
    
}