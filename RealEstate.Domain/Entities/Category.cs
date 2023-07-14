using RealEstate.Domain.Common;

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