using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDBContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
