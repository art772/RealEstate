using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Commands.CreateEstate
{
    public class CreateEstateCommandHandler : IRequestHandler<CreateEstateCommand, int>
    {
        private readonly IEstateDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateEstateCommandHandler(IEstateDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            var genreCount = _context.Genres.Count();
            var categoryCount = _context.Categories.Count();
            var stateCount = _context.States.Count();

            var httpContext = _httpContextAccessor.HttpContext;

            var userName = httpContext.User.FindFirstValue(ClaimTypes.Name);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            Estate estate = new()
            {
                Name = request.Name,
                Description = request.Description,
                Street = request.Street,
                StreetNumber = request.StreetNumber,
                FlatNumber = request.FlatNumber,
                City = request.City,
                ZipCode = request.ZipCode,
                Country = request.Country,
                Price = request.Price,
                EstateArea = request.EstateArea,
                YearOfConstruction = request.YearOfConstruction,
                GenreId = request.GenreId,
                CategoryId = request.CategoryId,
                StateId = request.StateId
            };

            if(request.GenreId > genreCount)
                throw new Exception($"Genre Id can't be higher than {genreCount}");
            
            if(request.CategoryId > categoryCount)
                throw new Exception($"Category Id can't be higher than {categoryCount}");
            
            if(request.StateId > stateCount)
                throw new Exception($"State Id can't be higher than {stateCount}");


            estate.ApplicationUserId = user.Id;

            _context.Estates.Add(estate);

            await _context.SaveChangesAsync(cancellationToken);

            return estate.Id;
        }
    }
}
