using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.EditUserData;
using RealEstate.Application.Users.Queries.GetUserDetails;
using RealEstate.Application.Users.Queries.GetUserEstates;

namespace RealEstate.Controllers.User
{
    [Route("api/user/{id}/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetDetail(int id)
        {

            return Ok(await Mediator.Send(new GetUserDetailsQuery() { UserId = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserEstates(int id)
        {
            return Ok(await Mediator.Send(new GetUserEstatesQuery() { UserId = id }));
        }

        [HttpPatch]
        public async Task<IActionResult> EditUserData(EditUserDataCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
