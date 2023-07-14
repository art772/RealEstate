using MediatR;
using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Users.Commands.UnbanUser
{
    public class UnbanUserCommandHandler : IRequestHandler<UnbanUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UnbanUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(UnbanUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null && user.IsBanned == true)
            {
                user.IsBanned = false;
            }
            else
            {
                throw new Exception("This user is not banned");
            }

            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}