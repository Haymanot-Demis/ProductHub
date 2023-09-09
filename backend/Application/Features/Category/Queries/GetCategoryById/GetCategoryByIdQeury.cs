using Application.DTO.Category;
using Application.DTO.Product;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<CategoryResponseDto>
{
    public int Id { get; set; }
}