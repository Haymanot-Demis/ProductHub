using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.DTO.User;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new LoginQueryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult.Errors);
        
        // user exists
        var user = await _userRepository.GetByEmailAsync(request.LoginDto.Email);
        
        if (user == null)
        {
            throw new Exception("Invalid credentials");
        }
        
        // password is correct
        var passwordValid = BCrypt.Net.BCrypt.Verify(request.LoginDto.Password, user.Password);
        
        if (!passwordValid)
        {
            throw new Exception("Invalid credentials");
        }
        
        // handler
        var token = _jwtTokenGenerator.GenerateToken(user.Email, user.UserName, user.Id);
        return new AuthResponse() { Token = token };
    }
}