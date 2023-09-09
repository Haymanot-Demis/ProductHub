using Application.DTO.User;
using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<UserEntity?> GetByUsernameAsync(string userName);
}