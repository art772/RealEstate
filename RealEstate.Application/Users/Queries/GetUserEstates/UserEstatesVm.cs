namespace RealEstate.Application.Users.Queries.GetUserEstates
{
    public class UserEstatesVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string FlatNumber { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public double EstateArea { get; set; }
        public int GenreId { get; set; }
        public int CategoryId { get; set; }
        public int StateId { get; set; }
    }
}