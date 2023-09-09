using Domain.Common;

namespace Domain.Entites;

public class UserEntity : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<ProductBooking> ProductBookings { get; set; } = null!;
    // public int RoleId { get; set; }
    // public RoleEntity Role { get; set; } = null!;
}