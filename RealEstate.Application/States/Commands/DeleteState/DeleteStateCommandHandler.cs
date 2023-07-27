using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            var state = await _context.States.Where(x => x.Id == request.StateId && x.StatusId == 1).FirstOrDefaultAsync(cancellationToken);

            if (state != null)
            {
                _context.States.Remove(state);

                await _context.SaveChangesAsync(cancellationToken);

                return state.Id;
            }
            else
            {
                throw new Exception("State does not exist");
            }
        }
    }
}