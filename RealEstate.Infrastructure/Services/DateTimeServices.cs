using RealEstate.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Services
{
    public class DateTimeServices : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
