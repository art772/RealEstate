using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace RealEstate.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task RegisterUserAsync()
        {

        }

    }
}
