using MediatR;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IEstateDbContext _context;

        public CreateGenreCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            Genre genre = new Genre()
            {
                Name = request.Name
            };

            await _context.Genres.AddAsync(genre);

            _context.SaveChangesAsync(cancellationToken);

            return genre.Id;
        }
    }
}