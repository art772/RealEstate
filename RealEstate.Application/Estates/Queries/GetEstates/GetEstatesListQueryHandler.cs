using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RealEstate.Application.Estates.Queries.GetEstates
{
    public class GetEstatesListQueryHandler : IRequestHandler<GetEstatesListQuery, List<EstateDto>>
    {    
        private readonly IEstateDbContext _context;

        public GetEstatesListQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstateDto>> Handle(GetEstatesListQuery request, CancellationToken cancellationToken)
        {
            var estates = await _context.Estates.Where(p => p.StatusId == 1).ToListAsync(cancellationToken);

            if(estates.Any())
            {
                return MapEstatesToVm(estates);
            }
            else
            {
                throw new Exception("Estates list is empty");
            }
        }

        private List<EstateDto> MapEstatesToVm(List<Estate> estates)
        {
            var result = new List<EstateDto>();

            foreach (var estate in estates)
            {
                var estateVm = new EstateDto()
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
