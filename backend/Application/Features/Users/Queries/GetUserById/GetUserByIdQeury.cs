using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserResponseDto>
{
    public int UserId { get; set; }
}