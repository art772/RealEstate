using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Genres.Queries.GetGenreToEdit
{
    public class GetGenreToEditQueryHandler : IRequestHandler<GetGenreToEditQuery, GenreToEditVm>
    {
        private readonly IEstateDbContext _context;

        public GetGenreToEditQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<GenreToEditVm> Handle(GetGenreToEditQuery request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FindAsync(request.GenreId);
            
            if (genre != null)
            {
                return MapGenreTOEditVm(genre);
            }
            else
            {
                throw new GenreDoesNotExistException();
            }
        }

        private GenreToEditVm MapGenreTOEditVm(Genre genre)
        {
            var genreVm = new GenreToEditVm()
            {
                GenreName = genre.Name,
            };
            return genreVm;
        }
    }
}