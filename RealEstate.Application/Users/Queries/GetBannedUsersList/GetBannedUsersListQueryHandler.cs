using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Queries.GetBannedUsersList
{
    public class GetBannedUsersListQueryHandler : IRequestHandler<GetBannedUsersListQuery, List<BannedUserVm>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetBannedUsersListQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<BannedUserVm>> Handle(GetBannedUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Where(p => p.IsBanned == true).ToListAsync(cancellationToken);

            return MapBannedUserToVm(users);
        }

        private List<BannedUserVm> MapBannedUserToVm(List<ApplicationUser> users)
        {
            var result = new List<BannedUserVm>();

            foreach (var user in users)
            {
                var userVm = new BannedUserVm()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                };

                result.Add(userVm);
            }

            return result;
        }
    }
}
