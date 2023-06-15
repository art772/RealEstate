using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.BanUser;
using RealEstate.Application.Users.Commands.UnbanUser;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails()
        {
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeRole()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetBannedUsers()
        {
            return Ok(await Mediator.Send(new GetBannedUsersListQuery()));
        }

        [HttpPatch]
        public async Task<IActionResult> BanUser(BanUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UnbanUser(UnbanUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
