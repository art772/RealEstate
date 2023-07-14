using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Common.Interfaces
{
    public interface IEstateDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Estate> Estates { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<State> States { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<EstateTag> EstateTags { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}