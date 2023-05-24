using MediatR;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.CreateEstate
{
    public class CreateEstateCommandHandler : IRequestHandler<CreateEstateCommand, int>
    {
        private readonly IEstateDbContext _context;
        public CreateEstateCommandHandler(IEstateDbContext estateDbContext)
        {
            _context = estateDbContext;
        }
        public async Task<int> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            Estate estate = new()
            {
                Name = request.Name,
                Description = request.Description,
                Street = request.Street,
                StreetNumber = request.StreetNumber,
                FlatNumber = request.FlatNumber,
                City = request.City,
                ZipCode = request.ZipCode,
                Country = request.Country,
                Price = request.Price,
                EstateArea = request.EstateArea,
                YearOfConstruction = request.YearOfConstruction,
                GenreId = 1,
                CategoryId = 1,
                StateId = 1
            };

            _context.Estates.Add(estate);

            await _context.SaveChangesAsync(cancellationToken);

            return estate.Id;
        }
    }
}
