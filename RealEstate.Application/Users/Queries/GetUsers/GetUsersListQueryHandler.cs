using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Users.Queries.GetUsers
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserListDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetUsersListQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<UserListDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync(cancellationToken);

            return MapUsersListVm(users);
        }

        private List<UserListDto> MapUsersListVm(List<ApplicationUser> users)
        {
            var result = new List<UserListDto>();

            foreach (var user in users)
            {
                var userVm = new UserListDto()
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
