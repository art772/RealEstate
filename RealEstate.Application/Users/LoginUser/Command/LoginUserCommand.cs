using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.LoginUser.Command
{
    public class LoginUserCommand : IRequest<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
