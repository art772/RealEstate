using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.RegisterUser;

namespace RealEstate.Controllers.User
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
