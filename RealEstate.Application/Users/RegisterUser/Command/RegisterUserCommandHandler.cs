using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.RegisterUser.Command
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterUserCommandHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var userEmail = await _userManager.FindByEmailAsync(request.Email);
            var userLogin = await _userManager.FindByNameAsync(request.UserName);


            if (userEmail != null)
            {
                throw new Exception("User with given e-mail address exists.");
            }
            else if (userLogin != null)
            {
                throw new Exception("User with given user name exists.");
            }
            else
            {
                IdentityUser newUser = new()
                {
                    UserName = request.UserName,
                    Email = request.Email
                };

                await _userManager.CreateAsync(newUser, request.Password);

                return 1;
            }
        }
    }
}
