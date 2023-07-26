using MediatR;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.States.Commands.RestoreState
{
    public class RestoreStateCommandHandler : IRequestHandler<RestoreStateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public RestoreStateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(RestoreStateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}