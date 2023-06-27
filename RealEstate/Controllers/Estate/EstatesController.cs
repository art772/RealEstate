using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RealEstate.Application.Estates.Commands.CreateEstate;
using RealEstate.Application.Estates.Commands.DeleteEstate;
using RealEstate.Application.Estates.Commands.RestoreEstate;
using RealEstate.Application.Estates.Commands.UpdateEstate;
using RealEstate.Application.Estates.Queries.GetEstateDetail;
using RealEstate.Application.Estates.Queries.GetEstates;
using RealEstate.Application.Estates.Queries.GetEstatesByCategory;
using System;

namespace RealEstate.Controllers.Estate
{
    [Route("api/estates/[action]")]
    public class EstatesController : BaseController
    {
        public EstatesController()
        {

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstatesByCategory(int id)
        {
            return Ok(await Mediator.Send(new GetEstatesListByCategoryQuery() { CategoryId = id }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateEstate(CreateEstateCommand command)
        {
            CreateEstateCommandValidator validation = new CreateEstateCommandValidator();

            var validationResult = await validation.ValidateAsync(command);

            if (validationResult.IsValid)
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
        [Authorize]
        public async Task<IActionResult> UpdateEstate(UpdateEstateCommand command)
        {
            UpdateEstateCommandValidator validation = new UpdateEstateCommandValidator();

            var validationResult = await validation.ValidateAsync(command);

            if(validationResult.IsValid)
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            else
            {
                throw new ValidationException(validationResult.Errors);
            }
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
