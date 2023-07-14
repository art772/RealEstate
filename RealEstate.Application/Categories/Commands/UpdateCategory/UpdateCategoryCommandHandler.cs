using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly IEstateDbContext _context;

        public UpdateCategoryCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(x => x.Id == request.CategoryId).FirstOrDefaultAsync();

            if (category != null)
            {
                category.Name = request.Name;

                await _context.SaveChangesAsync(cancellationToken);

                return category.Id;
            }
            else
            {
                throw new CategoryDoesNotExistException();
            }
        }
    }
}