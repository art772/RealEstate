using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Categories.Commands.RestoreCategory
{
    public class RestoreCategoryCommandHandler : IRequestHandler<RestoreCategoryCommand, int>
    {
        private readonly IEstateDbContext _context;

        public RestoreCategoryCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RestoreCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(x => x.StatusId == 0 && x.Id == request.CategoryId).FirstOrDefaultAsync();

            if (category != null)
            {
                category.StatusId = 1;

                await _context.SaveChangesAsync(cancellationToken);

                return category.Id;
            }
            else
            {
                throw new Exception("Category is not delete");
            }
        }
    }
}
