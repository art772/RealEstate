using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Commands.UnbanUser
{
    public class UnbanUserCommand : IRequest
    {
        public string UserName { get;set; }
    }
}
