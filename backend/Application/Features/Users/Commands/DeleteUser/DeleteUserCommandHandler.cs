using Application.Contracts.Persistence;
using FluentValidation;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUser.DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new DeleteUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult.Errors);
        }
        // check if user exists
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new Exception($"User with id {request.UserId} not found");
        }
        await _userRepository.DeleteAsync(user);
        return Unit.Value;
    }
}