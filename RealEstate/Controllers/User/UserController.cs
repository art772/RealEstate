using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealEstate.Application.Estates.Queries.GetUserDetails;
using RealEstate.Application.Estates.Queries.GetUserEstates;

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
    }
}
