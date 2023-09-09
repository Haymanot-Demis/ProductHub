using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    private readonly AppDBContext _dbContext;
    
    public UserRepository(AppDBContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<UserEntity?> GetByUsernameAsync(string userName)
    {
        return _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    }

    Task<UserEntity?> IUserRepository.GetByEmailAsync(string email)
    {
        return _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
    
}