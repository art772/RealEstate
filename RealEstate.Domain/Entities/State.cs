using RealEstate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class State : AuditableEntity
    {
        // One State has many Estates

        // Available, unavailable, reservation, sold
        public string Name { get; set; }
        public ICollection<Estate> Estates { get; set; }
    }
}
