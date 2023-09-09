using Application.Contracts.Persistence;
using Domain.Entites;

namespace Persistence.Repositories;

public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(AppDBContext dbContext) : base(dbContext)
    {
    }

    public Task<CategoryEntity?> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}