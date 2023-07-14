using MediatR;

namespace RealEstate.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}