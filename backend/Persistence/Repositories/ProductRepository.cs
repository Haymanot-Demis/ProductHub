using Application.Contracts.Persistence;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
{
   private readonly AppDBContext _dbContext;

   public ProductRepository(AppDBContext dbContext) : base(dbContext)
   {
      _dbContext = dbContext;
   }
}