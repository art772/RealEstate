using MediatR;

namespace RealEstate.Application.Genres.Queries.GetGenreToEdit
{
    public class GetGenreToEditQuery : IRequest<GenreToEditVm>
    {
        public int GenreId { get;set; }
    }
}