using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using RealEstate.Persistance.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistance
{
    public class EstateDbContext : DbContext
    {
        private readonly IDateTime _dateTime;
        public EstateDbContext(DbContextOptions<EstateDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = string.Empty;
                        entry.Entity.CreatedDate = _dateTime.Now;
                        entry.Entity.StatusId = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.ModifiedBy = string.Empty;
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.InactivatedBy = string.Empty;
                        entry.Entity.InactivatedDate = _dateTime.Now;
                        entry.Entity.StatusId = 0;
                        entry.State = EntityState.Modified;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
