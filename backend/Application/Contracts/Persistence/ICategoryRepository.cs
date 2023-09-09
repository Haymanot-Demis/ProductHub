using Application.DTO.User;
using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<CategoryEntity>
{
    Task<CategoryEntity?> GetByNameAsync(string name);
}