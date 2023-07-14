using MediatR;

namespace RealEstate.Application.Admin.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoriesVm>>
    {
    }
}