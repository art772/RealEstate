using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System.Security.Claims;
using System.Threading;

namespace RealEstate.Application.Estates.Commands.UpdateEstate
{
    public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateCommand, int>
    {
        private readonly IEstateDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateEstateCommandHandler(IEstateDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            
            var userName = httpContext.User.FindFirstValue(ClaimTypes.Name);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            var estate = await _context.Estates.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (estate == null)
            {
                throw new InvalidEstateIdException(request.Id);
            }

            if (user.Id != estate.ApplicationUserId)
            {
                throw new NotYourEstateException();
            }

            estate.Name = request.Name;
            estate.Description = request.Description;
            estate.Street = request.Street;
            estate.StreetNumber = request.StreetNumber;
            estate.FlatNumber = request.FlatNumber;
            estate.City = request.City;
            estate.ZipCode = request.ZipCode;
            estate.Country = request.Country;
            estate.Price = request.Price;
            estate.EstateArea = request.EstateArea;
            estate.YearOfConstruction = request.YearOfConstruction;

            await _context.SaveChangesAsync(cancellationToken);

            return estate.Id;
        }
    }
}
