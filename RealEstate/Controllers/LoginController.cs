using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.LoginUser.Command;

namespace RealEstate.Controllers
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
