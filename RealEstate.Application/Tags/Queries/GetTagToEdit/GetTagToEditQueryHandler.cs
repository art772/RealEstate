using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tags.Queries.GetTagToEdit
{
    public class GetTagToEditQueryHandler : IRequestHandler<GetTagToEditQuery, TagToEditVm>
    {
        private readonly IEstateDbContext _context;

        public GetTagToEditQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<TagToEditVm> Handle(GetTagToEditQuery request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.Where(x => x.Id == request.TagId).FirstOrDefaultAsync(cancellationToken);

            return MapTagToVm(tag);
        }

        private TagToEditVm MapTagToVm(Tag tag)
        {
            var tagVm = new TagToEditVm()
            {
                Id = tag.Id,
                Name = tag.Name
            };
            return tagVm;
        }
    }
}