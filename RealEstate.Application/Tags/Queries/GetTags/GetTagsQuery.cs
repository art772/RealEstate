using MediatR;

namespace RealEstate.Application.Admin.Queries.GetTags
{
    public class GetTagsQuery : IRequest<List<TagsVm>>
    {
    }
}