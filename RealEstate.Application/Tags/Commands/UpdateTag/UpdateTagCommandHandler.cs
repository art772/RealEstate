using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, int>
    {
        private readonly IEstateDbContext _context;

        public UpdateTagCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.Where(x => x.Id == request.TagId).FirstOrDefaultAsync(cancellationToken);

            if (tag != null)
            {
                tag.Name = request.Name;

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