using RealEstate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class Estate : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string FlatNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public double EstateArea { get; set; }
        public int YearOfConstruction { get; set; }

        // One Estate has one Genre
        public int GenreId { get; set; }
        public Genre Genre { get; set; } // Home, flat, apartament ...

        // One Estate has one Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } // For sale or for rent

        // One Estate has one State
        public int StateId { get; set; }
        public State State { get; set; } // Available, unavailable, reservation, sold

        // One Estate has many Tags
        public ICollection<Tag> Tags { get; set; } // Garden, elevator, pool ...
    }
}
