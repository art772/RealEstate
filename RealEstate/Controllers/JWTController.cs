using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    [Route("api/jwt/[action]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        [HttpGet]
        public IActionResult PublicAPI()
        {
            return Ok("Hey this is public API");
        }

        [HttpGet]
        [Authorize]
        public IActionResult PrivateAPI()
        {
            return Ok("Hey pssst... this is PRIVATE API");
        }
    }
}
