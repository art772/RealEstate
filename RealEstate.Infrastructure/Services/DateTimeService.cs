using RealEstate.Application.Common.Interfaces;

namespace RealEstate.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}