using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Queries.GetUsers;

namespace RealEstate.Controllers.Admin
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }
    }
}
