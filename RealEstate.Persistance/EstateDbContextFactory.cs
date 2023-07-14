using Microsoft.EntityFrameworkCore;

namespace RealEstate.Persistance
{
    public class EstateDbContextFactory : DesignTimeDbContextFactoryBase<EstateDbContext>
    {
        protected override EstateDbContext CreateNewInstance(DbContextOptions<EstateDbContext> options)
        {
            return new EstateDbContext(options);
        }
    }
}