using MediatR;

namespace RealEstate.Application.Tags.Queries.GetTagDetails
{
    public class GetTagDetailsQuery : IRequest<TagDetailsVm>
    {
        public int TagId { get; set; }
    }
}