using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Users.Commands.BanUser
{
    public class BanUserCommandHandler : IRequestHandler<BanUserCommand, int>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BanUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<int> Handle(BanUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null && user.IsBanned == false)
            {
                user.IsBanned = true;
            }
            else
            {
                throw new Exception("This user is already banned");
            }

            await _userManager.UpdateAsync(user);

            return user.Id;
        }
    }
}