using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Common;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
                ApplicationUser newUser = new()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };

                await _userManager.CreateAsync(newUser, request.Password);

                await _userManager.AddToRoleAsync(newUser, "User");

                return newUser.Id;
            }
        }
    }
}
