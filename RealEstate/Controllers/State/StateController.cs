using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Controllers.State
{
    [Route("api/states/[action]")]
    [ApiController]
    public class StateController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetStateDetails(int id)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> CreateState()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateState(string tutajBedzieCommand)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> EditState(int id)
        {
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> EditState()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteState()
        {
            return Ok();
        }
    }
}