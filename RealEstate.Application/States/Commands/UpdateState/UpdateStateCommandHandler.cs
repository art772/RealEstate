using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.States.Commands.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public UpdateStateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var state = await _context.States.Where(x => x.Id == request.StateId).FirstOrDefaultAsync(cancellationToken);

            if (state != null)
            {
                state.Name = request.StateName;

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