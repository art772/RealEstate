using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
