using MediatR;

namespace RealEstate.Application.Estates.Queries.GetEstatesByCategory
{
    public class GetEstatesListByCategoryQuery : IRequest<List<EstateByCategoryVm>>
    {
        public int CategoryId { get; set; }
    }
}