using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RealEstate.Application.Estates.Commands.UpdateEstate
{
    public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public UpdateEstateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = await _context.Estates.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (estate == null)
            {
                throw new Exception($"Estate with Id: {request.Id} does not exist");
            }

            estate.Name = request.Name;
            estate.Description = request.Description;
            estate.Street = request.Street;
            estate.StreetNumber = request.StreetNumber;
            estate.FlatNumber = request.FlatNumber;
            estate.City = request.City;
            estate.ZipCode = request.ZipCode;
            estate.Country = request.Country;
            estate.Price = request.Price;
            estate.EstateArea = request.EstateArea;
            estate.YearOfConstruction = request.YearOfConstruction;

            //_context.Estates.Update(estate);

            await _context.SaveChangesAsync(cancellationToken);

            return estate.Id;
        }
    }
}
