using FluentValidation;

namespace Application.Features.Users.Queries.GetUserByEmail;

public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address.")
            .NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
    }
}