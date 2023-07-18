using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;

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
            var estate = await _context.Estates.SingleOrDefaultAsync(p => p.Id == request.EstateId && p.StatusId == 0);

            if (estate != null)
            {
                estate.StatusId = 1;
            }
            else
            {
                throw new NotDeletedEstateException(request.EstateId);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return estate.Id;
        }
    }
}