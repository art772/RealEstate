using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Exceptions;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RealEstate.Application.Users.Queries.GetUserEstates
{
    public class GetUserEstatesQueryHandler : IRequestHandler<GetUserEstatesQuery, List<UserEstatesVm>>
    {
        private readonly IEstateDbContext _context;

        public GetUserEstatesQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserEstatesVm>> Handle(GetUserEstatesQuery request, CancellationToken cancellationToken)
        {
            var estates = await _context.Estates.Where(x => x.ApplicationUserId == request.UserId && x.StatusId == 1).ToListAsync(cancellationToken);

            if (estates.Any())
            {
                return MapUserEstatesToVm(estates);
            }
            else
            {
                throw new EstatesListEmptyException();
            }
        }

        private List<UserEstatesVm> MapUserEstatesToVm(List<Estate> estates)
        {
            var estateList = new List<UserEstatesVm>();

            foreach (var estate in estates)
            {
                var estateVm = new UserEstatesVm()
                {
                    Id = estate.Id,
                    Name = estate.Name,
                    Street = estate.Street,
                    StreetNumber = estate.StreetNumber,
                    FlatNumber = estate.FlatNumber,
                    City = estate.City,
                    Price = estate.Price,
                    EstateArea = estate.EstateArea,
                    GenreId = estate.GenreId,
                    CategoryId = estate.CategoryId,
                    StateId = estate.StateId
                };
                estateList.Add(estateVm);
            }
            return estateList;
        }
    }
}
