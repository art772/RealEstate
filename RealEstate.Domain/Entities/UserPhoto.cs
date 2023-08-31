using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class UserPhoto : Photo
    {
        public int? AppUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}