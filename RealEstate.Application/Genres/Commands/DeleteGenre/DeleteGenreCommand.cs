using MediatR;

namespace RealEstate.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommand : IRequest
    {
        public int GenreId { get; set; }
    }
}