using Application.DTO.Common;

namespace Application.DTO.Category;

public class CategoryResponseDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}