using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistance
{
    public static class EstateDbContextSeed
    {
        public static async Task SeedUserRolesAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.SuperAdministrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Roles.User.ToString()));
        }
    }
}
