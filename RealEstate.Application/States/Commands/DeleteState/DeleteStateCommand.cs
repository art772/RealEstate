using MediatR;

namespace RealEstate.Application.States.Commands.DeleteState
{
    public class DeleteStateCommand : IRequest<int>
    {
        public int StateId { get; set; }
    }
}