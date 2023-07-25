using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Admin.Queries.GetTags;
using RealEstate.Application.Tags.Commands.CreateTag;
using RealEstate.Application.Tags.Commands.DeleteTag;
using RealEstate.Application.Tags.Commands.RestoreTag;
using RealEstate.Application.Tags.Commands.UpdateTag;
using RealEstate.Application.Tags.Queries.GetTagDetails;
using RealEstate.Application.Tags.Queries.GetTagToEdit;

namespace RealEstate.Controllers.Tag
{
    [Route("api/tags/[action]")]
    [ApiController]
    public class TagController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            return Ok(await Mediator.Send(new GetTagsQuery()));
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
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> EditTag(int id)
        {
            return Ok(await Mediator.Send(new GetTagToEditQuery() { TagId = id }));
        }

        [HttpPatch]
        public async Task<IActionResult> EditTag(UpdateTagCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            return Ok(await Mediator.Send(new DeleteTagCommand() { TagId = id }));
        }

        [HttpPatch]
        public async Task<IActionResult> RestoreTag(int id)
        {
            return Ok(await Mediator.Send(new RestoreTagCommand() { TagId = id }));
        }
    }
}