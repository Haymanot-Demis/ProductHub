using Application.DTO.Common;
using FluentValidation;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.CreateUserDto.UserName)
            .NotEmpty()
            .Length(3, 20)
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("{PropertyName} must contain only alphanumeric characters and underscores.");


        RuleFor(user => user.CreateUserDto.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(user => user.CreateUserDto.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Za-z]")
            .Matches("[0-9]");
    }
}