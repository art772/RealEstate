using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUserDetailsQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users
                .Include(x => x.UserPhoto)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                throw new UserDoesNotExistException();
            }
            else
            {
                return MapUserToVm(user);
            }
        }

        private UserDetailsVm MapUserToVm(ApplicationUser user)
        {
            var userDetail = new UserDetailsVm()
            {
                UserName = user.UserName,
                UserEmail = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            if (user.UserPhoto != null)
            {
                userDetail.Photo = user.UserPhoto;
            }

            return userDetail;
        }
    }
}