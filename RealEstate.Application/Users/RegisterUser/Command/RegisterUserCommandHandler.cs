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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<ApplicatonUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserDbContext _context;

        public RegisterUserCommandHandler(UserManager<ApplicatonUser> userManager, RoleManager<IdentityRole> roleManager, IUserDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new RegisterUserCommand
            {
                UsertName = request.UsertName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

            if (userWithSameEmail == null)
            {
                await _userManager.CreateAsync(user, request.Password);
                return Unit.Value;
            }
            else
            {
                return Unit.Value;
            }
        }
    }
}
