using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstateDetail
{
    public class GetEstateDetailQueryHandler : IRequestHandler<GetEstateDetailQuery, EstateDetailVm>
    {
        private readonly IEstateDbContext _context;
        public GetEstateDetailQueryHandler(IEstateDbContext estateDbContext)
        {
            _context = estateDbContext;
        }
        public async Task<EstateDetailVm> Handle(GetEstateDetailQuery request, CancellationToken cancellationToken)
        {
            var estate = await _context.Estates.Where(p => p.Id == request.EstateId && p.StatusId == 1).FirstOrDefaultAsync(cancellationToken);

            if (estate == null) {
                throw new InvalidEstateIdException(request.EstateId);
            }
            else
            {
                var estateVm = new EstateDetailVm()
                {
                    Name = estate.Name.ToString(),
                    Description = estate.Description.ToString(),
                    Street = estate.Street.ToString(),
                    StreetNumber = estate.StreetNumber.ToString(),
                    FlatNumber = estate.FlatNumber.ToString(),
                    City = estate.City.ToString(),
                    ZipCode = estate.ZipCode.ToString(),
                    Country = estate.Country.ToString(),
                    Price = estate.Price,
                    EstateArea = estate.EstateArea,
                    YearOfConstruction = estate.YearOfConstruction
                };

                return estateVm;
            }
        }
    }
}
