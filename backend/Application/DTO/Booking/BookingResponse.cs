using Application.DTO.Common;
using Application.DTO.Product;
using Application.DTO.User;

namespace Application.DTO.Booking;

public class BookingResponse : BaseDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProductResponseDto Product { get; set; } = null!;
    public UserResponseDto User { get; set; } = null!;
    public int Count { get; set; }
}