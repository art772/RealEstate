using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Queries.BannedUserList
{
    public class BannedUserListQuery : IRequest<List<BannedUserDto>>
    {
    }
}
