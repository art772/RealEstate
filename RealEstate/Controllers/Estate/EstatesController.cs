using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Estates.Commands.CreateEstate;
using RealEstate.Application.Estates.Commands.DeleteEstate;
using RealEstate.Application.Estates.Commands.RestoreEstate;
using RealEstate.Application.Estates.Commands.UpdateEstate;
using RealEstate.Application.Estates.Queries.GetEstateDetail;
using RealEstate.Application.Estates.Queries.GetEstates;

namespace RealEstate.Controllers.Estate
{
    [Route("api/estates")]
    public class EstatesController : BaseController
    {
        private readonly IValidator<CreateEstateCommand> _validator;

        public EstatesController(IValidator<CreateEstateCommand> validator)
        {
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstates()
        {
            return Ok(await Mediator.Send(new GetEstatesListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstateDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetEstateDetailQuery() { EstateId = id });
            return vm;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateEstate(CreateEstateCommand command)
        {
            ValidationResult res = await _validator.ValidateAsync(command);

            if (res.IsValid)
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            return Ok(await Mediator.Send(new DeleteEstateCommand { EstateId = id }));
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateEstate(UpdateEstateCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<int> RestoreEstate(RestoreEstateCommand command)
        {
            await Mediator.Send(command);

            return command.EstateId;
        }
    }
}
