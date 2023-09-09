using FluentValidation;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        When(dto => !string.IsNullOrEmpty(dto.CreateUserDto.UserName), () =>
        {
            RuleFor(x => x.CreateUserDto.UserName).MinimumLength(10).WithMessage("{PropertyName} must either empty or length of greater than 10");
        });
        
        When(dto => !string.IsNullOrEmpty(dto.CreateUserDto.Password), () =>
        {
            RuleFor(x => x.CreateUserDto.Password).MinimumLength(10)
                .NotEmpty()
                .MinimumLength(8).WithMessage("{PropertyName} must be greater or equal to than 8")
                .Matches("[A-Za-z]").WithMessage("{PropertyName} must contain at least one letter")
                .Matches("[0-9]").WithMessage("{PropertyName} must contain at least one number");
        });
            
        When(dto => dto.UserId != 0, () =>
        {
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater or equal to than 1");
        });
    }
}