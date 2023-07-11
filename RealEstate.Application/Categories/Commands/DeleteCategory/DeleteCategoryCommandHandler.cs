﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly IEstateDbContext _context;

        public DeleteCategoryCommandHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(x => x.Id == request.CategoryId).Where(x => x.StatusId == 1).FirstOrDefaultAsync(cancellationToken);

            if(category != null)
            {
                _context.Categories.Remove(category);

                await _context.SaveChangesAsync(cancellationToken);

                return "Category was deleted"; ;
            }
            else
            {
                return "Category does not exist";
            }           
        }
    }
}
