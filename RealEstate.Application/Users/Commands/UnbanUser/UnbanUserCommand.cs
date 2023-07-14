using MediatR;

namespace RealEstate.Application.Users.Commands.UnbanUser
{
    public class UnbanUserCommand : IRequest
    {
        public string UserName { get; set; }
    }
}