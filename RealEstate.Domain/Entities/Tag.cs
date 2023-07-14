using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Tag : AuditableEntity
    {
        // One Tag has many Estates

        // Garden, elevator, pool ...
        public string Name { get; set; }

        public string? Value { get; set; }
        public ICollection<EstateTag> EstateTags { get; set; }
    }
}