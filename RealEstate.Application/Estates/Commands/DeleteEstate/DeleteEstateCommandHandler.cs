using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.DeleteEstate
{
    public class DeleteEstateCommandHandler : IRequestHandler<DeleteEstateCommand>
    {
        private readonly IEstateDbContext _context;
        public DeleteEstateCommandHandler(IEstateDbContext estateDbContext)
        {
            _context = estateDbContext;
        }

        public async Task<Unit> Handle(DeleteEstateCommand request, CancellationToken cancellationToken)
        {
            var estate = await _context.Estates.Where(p => p.Id == request.EstateId).FirstOrDefaultAsync();

            _context.Estates.Remove(estate);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
