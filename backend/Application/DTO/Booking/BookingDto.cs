namespace Application.DTO.Booking;

public class BookingDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
}