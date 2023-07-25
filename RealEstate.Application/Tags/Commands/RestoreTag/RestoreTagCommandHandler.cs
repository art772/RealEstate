using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Tags.Commands.RestoreTag
{
    public class RestoreTagCommandHandler : IRequestHandler<RestoreTagCommand, int>
    {
        private readonly IEstateDbContext _context;

        public RestoreTagCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RestoreTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.Where(x => x.Id == request.TagId && x.StatusId == 0).FirstOrDefaultAsync(cancellationToken);

            if (tag != null)
            {
                tag.StatusId = 1;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Tag does not exist");
            }

            return tag.Id;
        }
    }   
}