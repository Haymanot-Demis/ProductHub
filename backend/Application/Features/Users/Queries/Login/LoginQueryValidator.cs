using FluentValidation;

namespace Application.Features.Users.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(u => u.LoginDto.Email)
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address.")
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(u => u.LoginDto.Password)
            .NotNull().WithMessage("{PropertyName} is required.");
    }
}