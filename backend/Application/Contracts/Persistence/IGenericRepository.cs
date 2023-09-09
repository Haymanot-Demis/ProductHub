using MediatR;

namespace Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    //get all
    public Task<IReadOnlyList<T>> GetAllAsync();

    //get by id
    public Task<T> GetByIdAsync(int Id);

    //create new
    public Task<T> CreateAsync(T entity);


    //update 
    public Task<T> UpdateAsync(T entity);


    //delete 
    public Task<Unit> DeleteAsync(T entity);
    
    // check if exists
    public Task<bool> Exists(int id);
}