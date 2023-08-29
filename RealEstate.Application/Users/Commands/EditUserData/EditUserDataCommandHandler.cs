using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using System.Security.Claims;

namespace RealEstate.Application.Users.Commands.EditUserData
{
    public class EditUserDataCommandHandler : IRequestHandler<EditUserDataCommand, int>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditUserDataCommandHandler(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Handle(EditUserDataCommand request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            var userName = httpContext.User.FindFirstValue(ClaimTypes.Name);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            // Dodać sprawdzenie od jakiego usera przychodzi rzadanie

            user.Email = request.UserEmail;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
                
            await _userManager.UpdateAsync(user);
            return user.Id;
        }

    }
}