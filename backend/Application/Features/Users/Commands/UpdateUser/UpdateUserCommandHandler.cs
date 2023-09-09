using Application.Contracts.Persistence;
using Application.DTO.User;
using Application.Exceptions;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUser.UpdateUserCommand, UserResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new NotFoundException($"User with id {request.UserId} doesn't exist");
        }
        
        _mapper.Map(request.CreateUserDto, user);
        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserResponseDto>(user);
    }
}