using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using System.Linq;

namespace RealEstate.Application.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IEstateDbContext _context;

        public DeleteGenreCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.Where(x => x.Id == request.GenreId).FirstOrDefaultAsync(cancellationToken);

            if (genre != null)
            {
                _context.Genres.Remove(genre);

                _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            else
            {
                throw new Exception("Genre does not exist");
            }
        }
    }
}