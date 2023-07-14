using MediatR;

namespace RealEstate.Application.Users.Queries.GetUserEstates
{
    public class GetUserEstatesQuery : IRequest<List<UserEstatesVm>>
    {
        public int UserId { get; set; }
    }
}