using Application.Contracts.Persistence;
using Application.DTO.User;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUser.CreateUserCommand, UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new CreateUserCommandValidator();
        var validationResult = validator.Validate(request);
        
        // validating the incoming request
        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult.Errors);
        }
        // checking if the user already exists
        
        var userExists = await _userRepository.GetByEmailAsync(request.CreateUserDto.Email);
        if (userExists != null)
        {
            throw new Exception("Email already exists");
        }
        
        // check if username exists
        var usernameExists = await _userRepository.GetByUsernameAsync(request.CreateUserDto.UserName);
        
        if (usernameExists != null)
        {
            throw new Exception("Username already exists");
        }
        
        // mapping the incoming request to the user entity
        var user = _mapper.Map<UserEntity>(request.CreateUserDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(request.CreateUserDto.Password);
        
        // adding the user to the database
        var newUser = await _userRepository.CreateAsync(user);
        return _mapper.Map<UserResponseDto>(newUser);
    }
}