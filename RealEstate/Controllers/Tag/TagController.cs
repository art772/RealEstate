using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Tags.Queries.GetTagDetails;

namespace RealEstate.Controllers.Tag
{
    [Route("api/tags/[action]")]
    [ApiController]
    public class TagController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTagDetails(int id)
        {
            return Ok(await Mediator.Send(new GetTagDetailsQuery() { TagId = id }));
        }

        [HttpGet]
        public async Task<IActionResult> CreateTag()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(string tutajBedzieCommand)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> EditTag(int id)
        {
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> EditTag()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag()
        {
            return Ok();
        }
    }
}