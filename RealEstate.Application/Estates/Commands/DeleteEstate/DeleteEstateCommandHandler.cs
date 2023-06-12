using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System.Security.Claims;
using System.Xml.Linq;

namespace RealEstate.Application.Estates.Commands.DeleteEstate
{
    public class DeleteEstateCommandHandler : IRequestHandler<DeleteEstateCommand>
    {
        private readonly IEstateDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteEstateCommandHandler(IEstateDbContext estateDbContext, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = estateDbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(DeleteEstateCommand request, CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            var userName = httpContext.User.FindFirstValue(ClaimTypes.Name);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            var estate = await _context.Estates.Where(p => p.Id == request.EstateId).FirstOrDefaultAsync();

            if (user.Id == estate.ApplicationUserId)
            {
                _context.Estates.Remove(estate);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            else
            {
                throw new Exception("This Estate doen not belong to You");
            }
        }
    }
}
