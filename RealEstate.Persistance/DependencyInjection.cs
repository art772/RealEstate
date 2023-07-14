using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEstateDbContext, EstateDbContext>();
            return services;
        }
    }
}