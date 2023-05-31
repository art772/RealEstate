using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Commands.BannedUser
{
    public class BannedUserCommandHandler : IRequestHandler<BannedUserCommand, int>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BannedUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<int> Handle(BannedUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null && user.IsBanned == false)
            {
                user.IsBanned = true;
            }

            await _userManager.UpdateAsync(user);

            return user.Id;
        }
    }
}
