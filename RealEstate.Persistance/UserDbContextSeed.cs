using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistance
{
    public class UserDbContextSeed
    {
        public static async Task SeedUserRolesAsync(UserManager<ApplicatonUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Roles.User.ToString()));
        }
    }
}
