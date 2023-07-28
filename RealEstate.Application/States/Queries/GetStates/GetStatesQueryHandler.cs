using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System.ComponentModel;

namespace RealEstate.Application.Admin.Queries.GetStates
{
    public class GetStatesQueryHandler : IRequestHandler<GetStatesQuery, List<StatesVm>>
    {
        private readonly IEstateDbContext _context;

        public GetStatesQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<StatesVm>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
        {
            var states = await _context.States.ToListAsync(cancellationToken);

            if (states != null)
            {
                return MapStatesToVm(states);
            }
            else
            {
                throw new Exception("States list is empty");
            }

        }

        private List<StatesVm> MapStatesToVm(List<State> states)
        {
            var result = new List<StatesVm>();

            foreach (var state in states)
            {
                var vm = new StatesVm()
                {
                    StateId = state.Id,
                    StateName = state.Name
                };
                result.Add(vm);
            }
            return result;
        }
    }
}