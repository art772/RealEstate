using MediatR;

namespace RealEstate.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}