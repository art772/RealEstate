using MediatR;

namespace RealEstate.Application.Genres.Commands.RestoreGenre
{
    public class RestoreGenreCommand : IRequest<int>
    {
        public int GenreId { get; set; }
    }
}