using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Admin.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoriesVm>>
    {
        private readonly IEstateDbContext _context;

        public GetCategoriesQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriesVm>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.Where(x => x.StatusId == 1).ToListAsync(cancellationToken);

            return MapCategoriesToVm(categories);
        }

        private List<CategoriesVm> MapCategoriesToVm(List<Category> categories)
        {
            var result = new List<CategoriesVm>();

            foreach(var category in categories)
            {
                var categoryVm = new CategoriesVm()
                {
                    Name = category.Name,
                };
                result.Add(categoryVm);
            }
            return result;
        }
    }
}
