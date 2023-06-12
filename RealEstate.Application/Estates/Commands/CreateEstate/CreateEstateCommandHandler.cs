using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        public CreateEstateCommandHandler(IEstateDbContext estateDbContext, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = estateDbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<int> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
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
                GenreId = 1,
                CategoryId = 1,
                StateId = 1
            };

            estate.ApplicationUserId = user.Id;

            _context.Estates.Add(estate);

            await _context.SaveChangesAsync(cancellationToken);

            return estate.Id;
        }
    }
}
