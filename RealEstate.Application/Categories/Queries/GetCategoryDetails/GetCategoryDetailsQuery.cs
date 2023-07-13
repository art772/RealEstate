using MediatR;

namespace RealEstate.Application.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQuery : IRequest<CategoryDetailsVm>
    {
        public int CategoryId { get; set; }
    }
}
