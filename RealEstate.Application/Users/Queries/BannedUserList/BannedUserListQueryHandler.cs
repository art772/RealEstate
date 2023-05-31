using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Queries.BannedUserList
{
    public class BannedUserListQueryHandler : IRequestHandler<BannedUserListQuery, List<BannedUserDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public BannedUserListQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<BannedUserDto>> Handle(BannedUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Where(p => p.IsBanned == true).ToListAsync(cancellationToken);

            return MapBannedUserToVm(users);
        }

        private List<BannedUserDto> MapBannedUserToVm(List<ApplicationUser> users)
        {
            var result = new List<BannedUserDto>();

            foreach (var user in users)
            {
                var userVm = new BannedUserDto()
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
