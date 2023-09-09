using Application.DTO.Product;
using Application.DTO.User;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ProductResponseDto>
{
    public int ProdId { get; set; }
    public CreateProdDto CreateProdDto { get; set; } = null!;
}