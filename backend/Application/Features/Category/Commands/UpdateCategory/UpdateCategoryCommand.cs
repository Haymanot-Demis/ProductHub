using Application.DTO.Category;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<CategoryResponseDto>
{
    public int Id { get; set; }
    public CreateCategoryDto CategoryDto { get; set; } = null!;
}