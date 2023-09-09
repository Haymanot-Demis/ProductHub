using Application.Contracts.Persistence;
using Domain.Entites;

namespace Persistence.Repositories;

public class BookingRepository : GenericRepository<ProductBooking>, IBookingRepository
{
    public BookingRepository(AppDBContext dbContext) : base(dbContext)
    {
    }
}