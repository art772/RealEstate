using MediatR;

namespace RealEstate.Application.Estates.Commands.CreateEstate
{
    public class CreateEstateCommand : IRequest<int>
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
        public int GenreId { get; set; }
        public int CategoryId { get; set; }
        public int StateId { get; set; }
        public string MarketType { get; set; }
        public string FinishState { get; set; }
        public int Floor { get; set; }
        public int NumberOfRooms { get; set; }

        //public List<int> EstateTags { get; set; }
    }
}