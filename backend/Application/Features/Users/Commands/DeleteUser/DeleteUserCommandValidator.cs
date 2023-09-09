using Application.DTO.Common;
using FluentValidation;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("{PropertyName} is required").GreaterThan(0).WithMessage("{PropertyName} can't be less than 1");
    }
}