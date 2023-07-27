using MediatR;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.States.Commands.CreateState
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public CreateStateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var tag = new State()
            {
                Name = request.Name,
            };
            await _context.States.AddAsync(tag);

            await _context.SaveChangesAsync(cancellationToken);

            return tag.Id;
        }
    }
}