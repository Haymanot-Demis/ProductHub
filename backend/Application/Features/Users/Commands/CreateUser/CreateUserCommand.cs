using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserResponseDto>
{
    public CreateUserDto CreateUserDto { get; set; } = null!;
}