using MediatR;

namespace RealEstate.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public int UserId { get; set; }
    }
}