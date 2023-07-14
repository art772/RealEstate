using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Estates.Queries.GetEstatesByState
{
    public class GetEstatesListByStateQueryHandler : IRequestHandler<GetEstatesListByStateQuery, List<EstateByStateVm>>
    {
        private readonly IEstateDbContext _context;

        public GetEstatesListByStateQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstateByStateVm>> Handle(GetEstatesListByStateQuery request, CancellationToken cancellationToken)
        {
            var estates = await _context.Estates.Where(x => x.StateId == request.SateId).ToListAsync(cancellationToken);

            if (estates.Any())
            {
                return MapEstatesToVm(estates);
            }
            else
            {
                throw new Exception("Estates list is empty");
            }
        }

        private List<EstateByStateVm> MapEstatesToVm(List<Estate> estates)
        {
            var result = new List<EstateByStateVm>();

            foreach (var estate in estates)
            {
                var estateVm = new EstateByStateVm()
                {
                    Id = estate.Id,
                    Name = estate.Name,
                    City = estate.City,
                    Price = estate.Price,
                    EstateArea = estate.EstateArea,
                    StatusId = estate.StatusId
                };
                result.Add(estateVm);
            }
            return result;
        }
    }
}