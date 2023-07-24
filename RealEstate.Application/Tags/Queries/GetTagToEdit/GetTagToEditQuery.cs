using MediatR;

namespace RealEstate.Application.Tags.Queries.GetTagToEdit
{
    public class GetTagToEditQuery : IRequest<TagToEditVm>
    {
        public int TagId { get; set; }
    }
}