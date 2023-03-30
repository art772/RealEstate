using RealEstate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class Category : AuditableEntity
    {
        // One Category has many Estates

        // For sale or for rent
        public string Name { get; set; }
        public ICollection<Estate> Estates { get; set; } // One category have a lot of estate
    }
}
