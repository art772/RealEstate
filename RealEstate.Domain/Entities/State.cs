using RealEstate.Domain.Common;

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