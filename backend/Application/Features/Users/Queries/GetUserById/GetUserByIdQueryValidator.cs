using FluentValidation;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(u => u.UserId)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");
    }
}