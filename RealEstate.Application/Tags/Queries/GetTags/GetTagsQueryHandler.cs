using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Admin.Queries.GetTags
{
    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, List<TagsVm>>
    {
        private readonly IEstateDbContext _context;

        public GetTagsQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<TagsVm>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _context.Tags.ToListAsync(cancellationToken);

            var tagList = new List<TagsVm>();

            foreach (var tag in tags)
            {
                var tagVm = new TagsVm()
                {
                    Id = tag.Id,
                    Name = tag.Name
                };
                tagList.Add(tagVm);
            }

            return tagList;
        }
    }
}