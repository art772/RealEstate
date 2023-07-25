using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, int>
    {
        private readonly IEstateDbContext _context;

        public DeleteTagCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.Where(x => x.Id == request.TagId && x.StatusId == 1).FirstOrDefaultAsync(cancellationToken);

            if (tag != null)
            {
                _context.Tags.Remove(tag);

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