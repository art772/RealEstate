using MediatR;

namespace RealEstate.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}