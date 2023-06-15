using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Commands.BanUser
{
    public class BanUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
    }
}
