using MediatR;

namespace RealEstate.Application.Categories.Commands.RestoreCategory
{
    public class RestoreCategoryCommand : IRequest<int>
    {
        public int CategoryId { get; set; }
    }
}