using Domain.Common;

namespace Domain.Entites;

public class RoleEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<UserEntity> Users { get; set; } = null!;

    public RoleEntity()
    {
        
    }
    
    public RoleEntity(string name)
    {
        Name = name;
    }
}