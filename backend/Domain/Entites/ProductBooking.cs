using Domain.Common;

namespace Domain.Entites;

public class ProductBooking : BaseEntity
{
    public DateTime EndDate { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public int Count { get; set; }
}