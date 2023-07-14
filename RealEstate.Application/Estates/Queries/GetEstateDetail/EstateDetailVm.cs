namespace RealEstate.Application.Estates.Queries.GetEstateDetail
{
    public class EstateDetailVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string FlatNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public double Price { get; set; }
        public double EstateArea { get; set; }
        public int YearOfConstruction { get; set; }
    }
}