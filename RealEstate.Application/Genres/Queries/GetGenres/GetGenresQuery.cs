using MediatR;

namespace RealEstate.Application.Admin.Queries.GetGenres
{
    public class GetGenresQuery : IRequest<List<GenresVm>>
    {
    }
}