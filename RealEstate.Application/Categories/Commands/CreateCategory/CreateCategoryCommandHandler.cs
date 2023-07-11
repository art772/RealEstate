using MediatR;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IEstateDbContext _context;

        public CreateCategoryCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new()
            {
                Name = request.Name
            };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
