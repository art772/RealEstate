using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.BannedUser;
using RealEstate.Application.Users.Queries.BannedUserList;

namespace RealEstate.Controllers.Admin
{
    [Route("api/banned-users")]
    [ApiController]
    [Authorize(Roles = "SuperAdministrator,Administrator")]
    public class BannedUsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetBannedUsersList()
        {
            return Ok(await Mediator.Send(new BannedUserListQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> BannedUser(BannedUserCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        //[HttpPost]
        //public void UnBannedUser()
        //{
        //}
    }
}
