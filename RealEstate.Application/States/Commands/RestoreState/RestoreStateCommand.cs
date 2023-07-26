using MediatR;

namespace RealEstate.Application.States.Commands.RestoreState
{
    public class RestoreStateCommand : IRequest<int>
    {
        public int StateId { get; set; }
    }
}