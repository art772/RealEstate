using MediatR;

namespace RealEstate.Application.Categories.Queries.GetCategoryToEdit
{
    public class GetCategoryToEditQuery : IRequest<CategoryToEditVm>
    {
        public int CategoryId { get; set; }
    }
}