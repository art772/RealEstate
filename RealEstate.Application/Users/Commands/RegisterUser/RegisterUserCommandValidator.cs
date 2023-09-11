using FluentValidation;

namespace RealEstate.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).MaximumLength(5);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4).MaximumLength(20);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
