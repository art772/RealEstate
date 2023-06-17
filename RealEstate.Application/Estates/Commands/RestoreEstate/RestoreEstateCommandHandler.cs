using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.RestoreEstate
{
    public class RestoreEstateCommandHandler : IRequestHandler<RestoreEstateCommand, int>
    {
        private readonly IEstateDbContext _context;

        public RestoreEstateCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RestoreEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = await _context.Estates.SingleOrDefaultAsync(p => p.Id == request.EstateId);

            if (estate != null)
            {
                estate.StatusId = 1;
            }
            else
            {
                throw new Exception($"Estate with this Id: {request.EstateId} is not deleted");
            }

            await _context.SaveChangesAsync(cancellationToken);

            return estate.Id;
        }
    }
}
