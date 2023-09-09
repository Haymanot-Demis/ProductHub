using Application.Contracts.Persistence;
using Application.DTO.User;
using Application.Features.Users.Queries.GetUserById;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper; 
    
    public GetUserByEmailQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<UserResponseDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new GetUserByEmailQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors);
        
        // handler
        var user = await _userRepository.GetByEmailAsync(request.Email);
        return _mapper.Map<UserResponseDto>(user);
    }
}