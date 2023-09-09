using Application.DTO.Product;
using Application.DTO.User;
using MediatR;

namespace Application.Features.Product.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductResponseDto>
{
    public int ProdId { get; set; }
}