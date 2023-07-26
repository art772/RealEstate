using MediatR;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.States.Commands.CreateState
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public CreateStateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}