using Application.DTO.Category;
using Application.DTO.Common;

namespace Application.DTO.Product;

public class ProductResponseDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryResponseDto Category { get; set; }
    public int AvailableQuantity { get; set; }
}