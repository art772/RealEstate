using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Categories.Queries.GetCategoryToEdit
{
    public class GetCategoryToEditQueryHandler : IRequestHandler<GetCategoryToEditQuery, CategoryToEditVm>
    {
        private readonly IEstateDbContext _context;

        public GetCategoryToEditQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryToEditVm> Handle(GetCategoryToEditQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(x => x.Id == request.CategoryId).FirstOrDefaultAsync(cancellationToken);

            if (category != null)
            {
                return MapCategorytoVm(category);
            }
            {
                throw new CategoryDoesNotExistException();
            }

        }

        private CategoryToEditVm MapCategorytoVm(Category category)
        {
            var categoryVm = new CategoryToEditVm()
            {
                Name = category.Name,
            };

            return categoryVm;
        }
    }
}
