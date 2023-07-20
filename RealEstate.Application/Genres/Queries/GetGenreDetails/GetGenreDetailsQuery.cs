using MediatR;

namespace RealEstate.Application.Genres.Queries.GetGenreDetails
{
    public class GetGenreDetailsQuery : IRequest<GenreDetailsVm>
    {
        public int GenreId { get; set; }
    }
}