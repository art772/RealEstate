using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Queries.UsersList
{
    public class UserListQuery : IRequest<List<UserListDto>>
    {
    }
}
