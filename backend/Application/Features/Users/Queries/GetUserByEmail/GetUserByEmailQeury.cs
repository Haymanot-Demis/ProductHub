using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Queries.GetUserByEmail;

public class GetUserByEmailQuery : IRequest<UserResponseDto>
{
    public string Email { get; set; } = null!;
}