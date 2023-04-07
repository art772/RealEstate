using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
