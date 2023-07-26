using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Application.States.Queries.GetStateDetails;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.States.Queries.GetStateToEdit
{
    public class GetStateToEditQueryHandler : IRequestHandler<GetStateToEditQuery, StateToEditVm>
    {
        private readonly IEstateDbContext _context;

        public GetStateToEditQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<StateToEditVm> Handle(GetStateToEditQuery request, CancellationToken cancellationToken)
        {
            var state = await _context.States.Where(x => x.Id == request.StateId).FirstOrDefaultAsync(cancellationToken);

            return MapStateToDetailVm(state);
        }

        private StateToEditVm MapStateToDetailVm(State state)
        {
            var result = new StateToEditVm()
            {
                StateId = state.Id,
                StateName = state.Name
            };
            return result;
        }
    }
}