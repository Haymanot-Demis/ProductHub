using Application.DTO.Booking;
using FluentValidation;
using MediatR;

namespace Application.Features.Booking.Command.CreateBooking;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        
    }
}