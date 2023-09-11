using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Users.Commands.RegisterUser;

namespace RealEstate.Controllers.Auth
{
    [Route("api/auth/register")]
    [ApiController]
    public class RegisterController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserCommand command)
        {
            RegisterUserCommandValidator validation = new RegisterUserCommandValidator();

            var validationResult = await validation.ValidateAsync(command);

            if (validationResult.IsValid)
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            else
            {
                var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(validationErrors);
            }

        }
    }
}