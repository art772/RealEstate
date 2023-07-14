using RealEstate.Domain.Common;

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