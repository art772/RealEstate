using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult PrivateAPI()
        {
            return Ok();
        }
    }
}
