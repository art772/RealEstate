using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;

namespace RealEstate.Persistance.Configuration
{
    public class EstateConfiguration : IEntityTypeConfiguration<Estate>
    {
        public void Configure(EntityTypeBuilder<Estate> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(3000).IsRequired();
        }
    }
}