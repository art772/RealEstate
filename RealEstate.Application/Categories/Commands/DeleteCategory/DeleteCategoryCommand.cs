using MediatR;

namespace RealEstate.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public int CategoryId { get; set; }
    }
}