using MediatR;

namespace RealEstate.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}