using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Genres.Commands.DeleteGenre;

namespace RealEstate.Controllers.Genre
{
    [Route("api/estates/[action]")]
    [ApiController]
    public class GenreController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> DeteleGenre(int id)
        {
            return Ok(Mediator.Send(new DeleteGenreCommand() { GenreId = id }));
        }
    }
}