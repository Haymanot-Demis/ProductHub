using Domain.Common;

namespace Domain.Entites;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    public int AvailableQuantity { get; set; }
    public ICollection<ProductBooking> ProductBookings { get; set; } = null!;
}