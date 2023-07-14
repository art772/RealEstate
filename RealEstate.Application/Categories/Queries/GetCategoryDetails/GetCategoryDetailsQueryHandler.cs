using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsVm>
    {
        private readonly IEstateDbContext _context;

        public GetCategoryDetailsQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDetailsVm> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
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

        private CategoryDetailsVm MapCategorytoVm(Category category)
        {
            var categoryVm = new CategoryDetailsVm()
            {
                Name = category.Name,
            };

            return categoryVm;
        }
    }
}