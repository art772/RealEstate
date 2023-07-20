using MediatR;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.Genres.Queries.GetGenreToEdit;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Genres.Queries.GetGenreDetails
{
    public class GetGenreDetailsQueryHandler : IRequestHandler<GetGenreDetailsQuery, GenreDetailsVm>
    {
        private readonly IEstateDbContext _context;

        public GetGenreDetailsQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<GenreDetailsVm> Handle(GetGenreDetailsQuery request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FindAsync(request.GenreId);

            if (genre != null)
            {
                return MapGenreToDetailVm(genre);
            }
            else
            {
                throw new GenreDoesNotExistException();
            }
        }

        private GenreDetailsVm MapGenreToDetailVm(Genre genre)
        {
            var genreVm = new GenreDetailsVm()
            {
                GenreName = genre.Name,
            };
            return genreVm;
        }
    }
}