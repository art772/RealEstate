using MediatR;

namespace RealEstate.Application.States.Queries.GetStateToEdit
{
    public class GetStateToEditQuery : IRequest<StateToEditVm>
    {
        public int StateId { get; set; }
    }
}