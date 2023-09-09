using Application.DTO.Category;
using Application.DTO.Product;
using Application.DTO.User;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryResponseDto>
{
    public CreateCategoryDto CreateCategoryDto { get; set; } = null!;
}