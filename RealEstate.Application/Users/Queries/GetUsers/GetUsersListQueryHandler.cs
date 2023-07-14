using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Users.Queries.GetUsers
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserListVm>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUsersListQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserListVm>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync(cancellationToken);

            return MapUsersListVm(users);
        }

        private List<UserListVm> MapUsersListVm(List<ApplicationUser> users)
        {
            var result = new List<UserListVm>();

            foreach (var user in users)
            {
                var userVm = new UserListVm()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsBanned = user.IsBanned,
                };

                result.Add(userVm);
            }

            return result;
        }
    }
}