using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Queries.GetUsers
{
    public class GetUsersListQuery : IRequest<List<UserListVm>>
    {
    }
}
