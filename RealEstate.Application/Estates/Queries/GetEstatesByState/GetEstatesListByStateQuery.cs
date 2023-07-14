using MediatR;

namespace RealEstate.Application.Estates.Queries.GetEstatesByState
{
    public class GetEstatesListByStateQuery : IRequest<List<EstateByStateVm>>
    {
        public int SateId { get; set; }
    }
}