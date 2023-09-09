using Application.DTO.Product;
using Application.DTO.User;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductResponseDto>
{
    public CreateProdDto CreateProductDto { get; set; } = null!;
}