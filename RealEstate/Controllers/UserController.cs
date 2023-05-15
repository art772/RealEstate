using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace RealEstate.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task UserList()
        {

        }

        [HttpPost]
        public async Task RegisterUser()
        {

        }

        public async Task LoginUser()
        {

        }
    }
}
