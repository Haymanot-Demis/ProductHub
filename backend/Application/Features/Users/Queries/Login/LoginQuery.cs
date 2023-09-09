using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Queries.Login;

public class LoginQuery : IRequest<AuthResponse>
{
    public LoginDto LoginDto { get; set; } = null!;
}