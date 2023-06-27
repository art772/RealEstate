using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstatesByCategory
{
    public class GetEstatesListByCategoryQueryHandler : IRequestHandler<GetEstatesListByCategoryQuery, List<EstateByCategoryDto>>
    {
        private readonly IEstateDbContext _context;

        public GetEstatesListByCategoryQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstateByCategoryDto>> Handle(GetEstatesListByCategoryQuery request, CancellationToken cancellationToken)
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

        private List<EstateByCategoryDto> MapEstatesToVm(List<Estate> estates)
        {
            var result = new List<EstateByCategoryDto>();

            foreach(var estate in estates)
            {
                var estateVm = new EstateByCategoryDto()
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
