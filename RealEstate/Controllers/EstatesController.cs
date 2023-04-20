using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Estates.Commands.CreateEstate;
using RealEstate.Application.Estates.Queries.GetEstateDetail;
using RealEstate.Domain.Entities;

namespace RealEstate.Controllers
{
    [Route("api/estates")]
    public class EstatesController : BaseController
    {
        private readonly IValidator<CreateEstateCommand> _validator;

        public EstatesController(IValidator<CreateEstateCommand> validator)
        {
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstateDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetEstateDetailQuery() { EstateId = id });
            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstate(CreateEstateCommand command)
        {
            ValidationResult res = await _validator.ValidateAsync(command);

            if(res.IsValid)
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
