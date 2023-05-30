using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Commands.BannedUser
{
    public class BannedUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public bool IsBanned { get; set;}
    }
}
