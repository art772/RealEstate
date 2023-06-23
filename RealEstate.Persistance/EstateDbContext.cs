using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using RealEstate.Persistance.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistance
{

    public class EstateDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>, IEstateDbContext
    {
        private readonly IDateTime _dateTime;

        public EstateDbContext(DbContextOptions<EstateDbContext> options) : base(options)
        {
        }

        public EstateDbContext(DbContextOptions<EstateDbContext> options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EstateTag> EstateTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<EstateTag>()
                .HasKey(et => new { et.EstateId, et.TagId });

            modelBuilder.Entity<EstateTag>()
                .HasOne(e => e.Estate)
                .WithMany(et => et.EstateTags)
                .HasForeignKey(e => e.EstateId);

            modelBuilder.Entity<EstateTag>()
                .HasOne(t => t.Tag)
                .WithMany(et => et.EstateTags)
                .HasForeignKey(t => t.TagId);


            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
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
