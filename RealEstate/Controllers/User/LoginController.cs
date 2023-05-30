using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.LoginUser;

namespace RealEstate.Controllers.User
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> LoginUserAsync(LoginUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
