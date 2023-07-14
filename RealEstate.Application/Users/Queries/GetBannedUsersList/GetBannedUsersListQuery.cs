using MediatR;

namespace RealEstate.Application.Users.Queries.GetBannedUsersList
{
    public class GetBannedUsersListQuery : IRequest<List<BannedUserVm>>
    {
    }
}