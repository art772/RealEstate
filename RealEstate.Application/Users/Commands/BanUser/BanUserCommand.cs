using MediatR;

namespace RealEstate.Application.Users.Commands.BanUser
{
    public class BanUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
    }
}