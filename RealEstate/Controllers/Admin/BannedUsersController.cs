using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.BannedUser;

namespace RealEstate.Controllers.Admin
{
    [Route("api/banned-users")]
    [ApiController]
    [Authorize(Roles = "SuperAdministrator,Administrator")]
    public class BannedUsersController : BaseController
    {
        //[HttpGet]
        //public void GetBannedUsersList()
        //{

        //}

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
