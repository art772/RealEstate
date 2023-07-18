using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == request.GenreId && x.StatusId == 0);

            if (genre != null)
            {
                genre.StatusId = 1;
            }
            else
            {
                throw new Exception("Genre is not deleted");
            }

            return genre.Id;
        }
    }
}