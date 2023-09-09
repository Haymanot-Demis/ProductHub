using System.Reflection.Metadata.Ecma335;
using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserResponseDto>>
{
    
}