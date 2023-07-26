using MediatR;

namespace RealEstate.Application.Admin.Queries.GetStates
{
    public class GetStatesQuery : IRequest<List<StatesVm>>
    {
    }
}