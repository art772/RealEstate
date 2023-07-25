using MediatR;

namespace RealEstate.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest<int>
    {
        public int TagId { get; set; }
    }
}