using Microsoft.AspNetCore.Identity;

namespace RealEstate.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBanned { get; set; }
        public virtual ICollection<Estate>? Estates { get; set; }
        public int? UserPhotoId { get; set; }
        public UserPhoto? UserPhoto { get; set; }
    }
}