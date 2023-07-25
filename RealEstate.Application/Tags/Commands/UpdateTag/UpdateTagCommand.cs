using MediatR;

namespace RealEstate.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest<int>
    {
        public int TagId { get; set; }
        public string Name { get; set; }
    }
}