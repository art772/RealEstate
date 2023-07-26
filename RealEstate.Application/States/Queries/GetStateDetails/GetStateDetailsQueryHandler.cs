using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.States.Queries.GetStateDetails
{
    public class GetStateDetailsQueryHandler : IRequestHandler<GetStateDetailsQuery, StateDetailsVm>
    {
        private readonly IEstateDbContext _context;

        public GetStateDetailsQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<StateDetailsVm> Handle(GetStateDetailsQuery request, CancellationToken cancellationToken)
        {
            var state = await _context.States.Where(x => x.Id == request.StateId).FirstOrDefaultAsync(cancellationToken);

            return MapStateToVm(state);
        }

        private StateDetailsVm MapStateToVm(State state)
        {
            var result = new StateDetailsVm()
            {
                StateId = state.Id,
                StateName = state.Name
            };
            return result;
        }
    }
}