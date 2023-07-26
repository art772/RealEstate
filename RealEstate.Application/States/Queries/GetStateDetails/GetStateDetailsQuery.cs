using MediatR;

namespace RealEstate.Application.States.Queries.GetStateDetails
{
    public class GetStateDetailsQuery : IRequest<StateDetailsVm>
    {
        public int StateId { get; set; }
    }
}