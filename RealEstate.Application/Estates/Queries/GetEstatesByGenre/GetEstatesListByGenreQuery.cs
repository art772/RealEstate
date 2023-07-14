using MediatR;

namespace RealEstate.Application.Estates.Queries.GetEstatesByGenre
{
    public class GetEstatesListByGenreQuery : IRequest<List<EstateByGenreVm>>
    {
        public int GenreId { get; set; }
    }
}