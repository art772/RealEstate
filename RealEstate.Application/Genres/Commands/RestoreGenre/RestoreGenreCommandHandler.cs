using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Genres.Commands.RestoreGenre
{
    public class RestoreGenreCommandHandler : IRequestHandler<RestoreGenreCommand, int>
    {
        private readonly IEstateDbContext _context;
        
        public RestoreGenreCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RestoreGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == request.GenreId && x.StatusId == 0, cancellationToken);

            if (genre != null)
            {
                genre.StatusId = 1;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new GenreDoesNotExistException();
            }

            return genre.Id;
        }
    }
}