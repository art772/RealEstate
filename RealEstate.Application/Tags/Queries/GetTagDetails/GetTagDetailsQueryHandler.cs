using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tags.Queries.GetTagDetails
{
    public class GetTagDetailsQueryHandler : IRequestHandler<GetTagDetailsQuery, TagDetailsVm>
    {
        private readonly IEstateDbContext _context;

        public GetTagDetailsQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<TagDetailsVm> Handle(GetTagDetailsQuery request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.Where(x => x.Id == request.TagId).FirstOrDefaultAsync(cancellationToken);

            if (tag != null)
            {
                return MapTagToVm(tag);
            }
            else
            {
                throw new TagDoesNotExistException();
            }
        }

        private TagDetailsVm MapTagToVm(Tag tag)
        {
            var tagDetailsVm = new TagDetailsVm()
            {
                TagName = tag.Name,
            };
            return tagDetailsVm;
        }
    }
}