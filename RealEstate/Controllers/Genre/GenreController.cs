using MediatR;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Admin.Queries.GetGenres;
using RealEstate.Application.Genres.Commands.DeleteGenre;
using RealEstate.Application.Genres.Commands.RestoreGenre;

namespace RealEstate.Controllers.Genre
{
    [Route("api/estates/[action]")]
    [ApiController]
    public class GenreController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(await Mediator.Send(new GetGenresQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GenreDetails()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> EditGenre()
        {
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateGenre()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeteleGenre(int id)
        {
            return Ok(Mediator.Send(new DeleteGenreCommand() { GenreId = id }));
        }

        [HttpGet]
        public async Task<IActionResult> RestoreGenre(int id)
        {
            return Ok(Mediator.Send(new RestoreGenreCommand() { GenreId = id }));
        }
    }
}