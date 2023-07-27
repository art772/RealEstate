using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> Handle(RestoreStateCommand request, CancellationToken cancellationToken)
        {
            var state = await _context.States.Where(x => x.Id == request.StateId && x.StatusId == 0).FirstOrDefaultAsync(cancellationToken);

            if (state != null)
            {
                state.StatusId = 1;

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