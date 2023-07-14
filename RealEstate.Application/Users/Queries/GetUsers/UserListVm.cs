namespace RealEstate.Application.Users.Queries.GetUsers
{
    public class UserListVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBanned { get; set; }
    }
}