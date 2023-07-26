using MediatR;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.States.Commands.DeleteState
{
    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public DeleteStateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}