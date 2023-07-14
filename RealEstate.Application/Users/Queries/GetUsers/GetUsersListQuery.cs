using MediatR;

namespace RealEstate.Application.Users.Queries.GetUsers
{
    public class GetUsersListQuery : IRequest<List<UserListVm>>
    {
    }
}