namespace RealEstate.Application.Estates.Queries.GetEstates
{
    public class EstateVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public double EstateArea { get; set; }
        public int StatusId { get; set; }
    }
}