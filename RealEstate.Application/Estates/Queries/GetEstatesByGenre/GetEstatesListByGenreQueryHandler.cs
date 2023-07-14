using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Estates.Queries.GetEstatesByGenre
{
    public class GetEstatesListByGenreQueryHandler : IRequestHandler<GetEstatesListByGenreQuery, List<EstateByGenreVm>>
    {
        private readonly IEstateDbContext _context;

        public GetEstatesListByGenreQueryHandler(IEstateDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstateByGenreVm>> Handle(GetEstatesListByGenreQuery request, CancellationToken cancellationToken)
        {
            var estates = await _context.Estates.Where(x => x.GenreId == request.GenreId).ToListAsync(cancellationToken);

            if (estates.Any())
            {
                return MapEstatesToVm(estates);
            }
            else
            {
                throw new Exception("Estates list is empty");
            }
        }

        private List<EstateByGenreVm> MapEstatesToVm(List<Estate> estates)
        {
            var result = new List<EstateByGenreVm>();

            foreach (var estate in estates)
            {
                var estateVm = new EstateByGenreVm()
                {
                    Id = estate.Id,
                    Name = estate.Name,
                    City = estate.City,
                    Price = estate.Price,
                    EstateArea = estate.EstateArea,
                    StatusId = estate.StatusId
                };
                result.Add(estateVm);
            }
            return result;
        }
    }
}