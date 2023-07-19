using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Admin.Queries.GetGenres
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, List<GenresVm>>
    {
        private readonly IEstateDbContext _context;

        public GetGenresQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<GenresVm>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            var genreList = await _context.Genres.Where(x => x.StatusId == 1).ToListAsync(cancellationToken);

            return MapGenresToVm(genreList);
        }

        private List<GenresVm> MapGenresToVm(List<Genre> genres)
        {
            var results = new List<GenresVm>();

            foreach (var genre in genres)
            {
                var genreVm = new GenresVm()
                {
                    GenreId = genre.Id,
                    GenreName = genre.Name,
                };
                results.Add(genreVm);
            }
            return results;
        }
    }
}