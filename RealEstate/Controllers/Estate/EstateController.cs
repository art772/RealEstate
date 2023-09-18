using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Estates.Commands.CreateEstate;
using RealEstate.Application.Estates.Commands.DeleteEstate;
using RealEstate.Application.Estates.Commands.RestoreEstate;
using RealEstate.Application.Estates.Commands.UpdateEstate;
using RealEstate.Application.Estates.Queries.GetEstateDetail;
using RealEstate.Application.Estates.Queries.GetEstates;
using RealEstate.Application.Estates.Queries.GetEstatesByCategory;
using RealEstate.Application.Estates.Queries.GetEstatesByGenre;
using RealEstate.Application.Estates.Queries.GetEstatesByState;

namespace RealEstate.Controllers.Estate
{
    [Route("api/estates/[action]")]
    public class EstateController : BaseController
    {
        public EstateController()
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
            return Ok(await Mediator.Send(new GetEstateDetailQuery() { EstateId = id }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstatesByCategory(int id)
        {
            return Ok(await Mediator.Send(new GetEstatesListByCategoryQuery() { CategoryId = id }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstatesByGenre(int id)
        {
            return Ok(await Mediator.Send(new GetEstatesListByGenreQuery() { GenreId = id }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstatesByState(int id)
        {
            return Ok(await Mediator.Send(new GetEstatesListByStateQuery() { SateId = id }));
        }

        //[Authorize]
        [HttpPost]
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
                //throw new ValidationException(validationResult.Errors);
                //throw new Exception("Nie udało się dodać nieruchomości");
                return BadRequest(validationResult);
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

            if (validationResult.IsValid)
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            else
            {
                var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(validationErrors);
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