using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.RegisterUser.Command;
using System.Formats.Asn1;

namespace RealEstate.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
