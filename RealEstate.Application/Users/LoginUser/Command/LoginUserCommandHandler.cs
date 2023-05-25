using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.LoginUser.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, int>
    {
        public Task<int> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
