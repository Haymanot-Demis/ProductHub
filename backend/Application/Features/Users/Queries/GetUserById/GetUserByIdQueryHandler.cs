using Application.Contracts.Persistence;
using Application.DTO.User;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper; 
    
    public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new GetUserByIdQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors);
        
        // handler
        var user = await _userRepository.GetByIdAsync(request.UserId);
        return _mapper.Map<UserResponseDto>(user);
    }
}