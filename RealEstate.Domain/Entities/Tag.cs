using RealEstate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain.Entities
{
    public class Tag : AuditableEntity
    {
        // One Tag has many Estates

        // Garden, elevator, pool ...
        public string Name { get; set; }
        public string? Value { get; set; }
        public ICollection<Estate> Estates { get; set; }
    }
}
