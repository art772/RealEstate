using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
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

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                IdentityUser newUser = new()
                {
                    UserName = request.UserName,
                    Email = request.Email
                };

                await _userManager.CreateAsync(newUser, request.Password);

                return 1;
            }
            else if (request.UserName == user.UserName)
            {
                throw new Exception("user with given user name exists");
            }
            else if (request.Email == user.Email)
            {
                throw new Exception("User with given e-mail address exists");
            }
            else
            {
                return 0;
            }
        }
    }
}
