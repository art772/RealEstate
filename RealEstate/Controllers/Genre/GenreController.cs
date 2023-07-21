using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Admin.Queries.GetGenres;
using RealEstate.Application.Genres.Commands.CreateGenre;
using RealEstate.Application.Genres.Commands.DeleteGenre;
using RealEstate.Application.Genres.Commands.RestoreGenre;
using RealEstate.Application.Genres.Commands.UpdateGenre;
using RealEstate.Application.Genres.Queries.GetGenreDetails;
using RealEstate.Application.Genres.Queries.GetGenreToEdit;

namespace RealEstate.Controllers.Genre
{
    [Route("api/genres/[action]")]
    [ApiController]
    public class GenreController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await Mediator.Send(new GetGenresQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(CreateGenreCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GenreDetails(int id)
        {
            return Ok(await Mediator.Send(new GetGenreDetailsQuery() { GenreId = id }));
        }

        [HttpGet]
        public async Task<IActionResult> EditGenre(int id)
        {
            return Ok(await Mediator.Send(new GetGenreToEditQuery() { GenreId = id }));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateGenre(UpdateGenreCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeteleGenre(int id)
        {
            return Ok(await Mediator.Send(new DeleteGenreCommand() { GenreId = id }));
        }

        [HttpPatch]
        public async Task<IActionResult> RestoreGenre(int id)
        {
            return Ok(await Mediator.Send(new RestoreGenreCommand() { GenreId = id }));
        }
    }
}