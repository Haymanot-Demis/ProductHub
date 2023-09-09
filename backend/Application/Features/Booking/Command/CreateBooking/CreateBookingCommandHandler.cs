using Application.Contracts.Persistence;
using Application.DTO.Booking;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Booking.Command.CreateBooking;

public class CreateBookingCommandHandler  :IRequestHandler<CreateBookingCommand, BookingResponse>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper, IUserRepository userRepository, IProductRepository productRepository)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task<BookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new CreateBookingCommandValidator();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        // check if product exists
        var product = await _productRepository.GetByIdAsync(request.BookingDto.ProductId);
        
        if (product == null)
        {
            throw new Exception($"Product with id {request.BookingDto.ProductId} not found");
        }
        
        var booking = _mapper.Map<ProductBooking>(request.BookingDto);
        booking.Product = product;
        booking.UserId= request.UserId;
        
        // check if booking is possible
        
        var newBooking = await _bookingRepository.CreateAsync(booking);
        return _mapper.Map<BookingResponse>(newBooking);
    }
}