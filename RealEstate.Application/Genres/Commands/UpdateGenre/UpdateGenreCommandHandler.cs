using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, int>
    {
        private readonly IEstateDbContext _context;

        public UpdateGenreCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == request.GenreId, cancellationToken);
            
            if (genre != null)
            {
                genre.Name = request.GenreName;

                await _context.SaveChangesAsync(cancellationToken);

                return genre.Id;
            }
            else
            {
                throw new GenreDoesNotExistException();
            }
        }
    }
}