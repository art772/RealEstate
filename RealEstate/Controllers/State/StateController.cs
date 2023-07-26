using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Admin.Queries.GetStates;
using RealEstate.Application.States.Commands.CreateState;
using RealEstate.Application.States.Commands.DeleteState;
using RealEstate.Application.States.Commands.RestoreState;
using RealEstate.Application.States.Commands.UpdateState;
using RealEstate.Application.States.Queries.GetStateDetails;
using RealEstate.Application.States.Queries.GetStateToEdit;

namespace RealEstate.Controllers.State
{
    [Route("api/states/[action]")]
    [ApiController]
    public class StateController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await Mediator.Send(new GetStatesQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> GetStateDetails(int id)
        {
            return Ok(await Mediator.Send(new GetStateDetailsQuery() {  StateId = id}));
        }

        [HttpGet]
        public async Task<IActionResult> CreateState()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateState(CreateStateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> EditState(int id)
        {
            return Ok(await Mediator.Send(new GetStateToEditQuery() { StateId = id }));
        }

        [HttpPatch]
        public async Task<IActionResult> EditState(UpdateStateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteState(int id)
        {
            return Ok(await Mediator.Send(new DeleteStateCommand() { StateId = id }));
        }

        [HttpPatch]
        public async Task<IActionResult> RestoreState(int id)
        {
            return Ok(await Mediator.Send(new RestoreStateCommand() { StateId = id }));
        }
    }
}