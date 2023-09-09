using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public int UserId { get; set; }
}