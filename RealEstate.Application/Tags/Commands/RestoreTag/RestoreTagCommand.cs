using MediatR;

namespace RealEstate.Application.Tags.Commands.RestoreTag
{
    public class RestoreTagCommand : IRequest<int>
    {
        public int TagId { get; set; }
    }
}