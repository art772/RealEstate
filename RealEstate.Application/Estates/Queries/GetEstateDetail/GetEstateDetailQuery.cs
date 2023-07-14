using MediatR;

namespace RealEstate.Application.Estates.Queries.GetEstateDetail
{
    public class GetEstateDetailQuery : IRequest<EstateDetailVm>
    {
        public int EstateId { get; set; }
    }
}