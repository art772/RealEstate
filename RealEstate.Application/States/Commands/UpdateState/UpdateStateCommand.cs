using MediatR;

namespace RealEstate.Application.States.Commands.UpdateState
{
    public class UpdateStateCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}