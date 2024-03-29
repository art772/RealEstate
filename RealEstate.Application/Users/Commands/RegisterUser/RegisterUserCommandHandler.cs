﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Users.Commands.RegisterUser
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
                    LastName = request.LastName,
                    IsBanned = false
                };

                await _userManager.CreateAsync(newUser, request.Password);

                await _userManager.AddToRoleAsync(newUser, "User");

                return newUser.Id;
            }
        }
    }
}