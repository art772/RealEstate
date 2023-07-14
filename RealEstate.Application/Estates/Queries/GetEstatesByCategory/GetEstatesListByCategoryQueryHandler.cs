using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Estates.Queries.GetEstatesByCategory
{
    public class GetEstatesListByCategoryQueryHandler : IRequestHandler<GetEstatesListByCategoryQuery, List<EstateByCategoryVm>>
    {
        private readonly IEstateDbContext _context;

        public GetEstatesListByCategoryQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstateByCategoryVm>> Handle(GetEstatesListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var estates = await _context.Estates.Where(x => x.CategoryId == request.CategoryId).ToListAsync(cancellationToken);

            if (estates.Any())
            {
                return MapEstatesToVm(estates);
            }
            else
            {
                throw new Exception("Estates list is empty");
            }
        }

        private List<EstateByCategoryVm> MapEstatesToVm(List<Estate> estates)
        {
            var result = new List<EstateByCategoryVm>();

            foreach (var estate in estates)
            {
                var estateVm = new EstateByCategoryVm()
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