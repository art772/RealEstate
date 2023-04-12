using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetEstates
{
    public class EstateDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public double EstateArea { get; set; }
    }
}
