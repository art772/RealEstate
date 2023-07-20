using MediatR;

namespace RealEstate.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand : IRequest<int>
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}