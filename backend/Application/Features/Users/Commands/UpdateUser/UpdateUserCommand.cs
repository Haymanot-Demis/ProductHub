using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UserResponseDto>
{
    public int UserId { get; set; }
    public CreateUserDto CreateUserDto { get; set; } = null!;
}