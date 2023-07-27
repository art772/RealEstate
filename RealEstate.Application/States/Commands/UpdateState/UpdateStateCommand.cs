using MediatR;

namespace RealEstate.Application.States.Commands.UpdateState
{
    public class UpdateStateCommand : IRequest<int>
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}