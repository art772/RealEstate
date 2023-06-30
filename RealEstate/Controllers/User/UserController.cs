using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers.User
{
    [Route("api/user/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail()
        {
            return Ok();
        }
    }
}
