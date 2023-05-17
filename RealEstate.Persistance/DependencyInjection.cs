using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EstateDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EstateDatabase")));
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EstateDatabase")));

            services.AddScoped<IEstateDbContext, EstateDbContext>();
            return services;
        }
    }
}
