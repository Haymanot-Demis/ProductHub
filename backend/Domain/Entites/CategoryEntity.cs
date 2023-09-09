using Domain.Common;

namespace Domain.Entites;

public class CategoryEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    public string Description { get; set; } = null!;
}