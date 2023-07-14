using MediatR;

namespace RealEstate.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}