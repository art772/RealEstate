using MediatR;

namespace RealEstate.Application.Estates.Queries.GetEstates
{
    public class GetEstatesListQuery : IRequest<List<EstateVm>>
    {
    }
}