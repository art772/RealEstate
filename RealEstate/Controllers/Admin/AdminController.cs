using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.BannedUser;
using RealEstate.Application.Users.Queries.GetBannedUsersList;
using RealEstate.Application.Users.Queries.GetUsers;

namespace RealEstate.Controllers.Admin
{
    [Route("api/admin/[action]")]
    [Authorize(Roles = "SuperAdministrator,Administrator")]
    public class AdminController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails()
        {
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeRole()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBanedUsers()
        {
            return Ok(await Mediator.Send(new GetBannedUsersListQuery()));
        }

        [HttpPatch]
        public async Task<IActionResult> BannedUser(BannedUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UnbanUser()
        {
            return Ok();
        }
    }
}
