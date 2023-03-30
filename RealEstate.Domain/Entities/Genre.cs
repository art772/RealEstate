using RealEstate.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RealEstate.Domain.Entities
{
    public class Genre : AuditableEntity
    {
        // One Genre has many Estates

        // Home, flat, apartament ...
        public string Name { get; set; }
        public ICollection<Estate> Estates { get; set; }
    }
}
