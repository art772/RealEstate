using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Estates.Queries.GetUserEstates
{
    public class UserEstatesVm
    {
        public string Id { get; set; }
        public string Title { get;set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string FlatNumber { get; set; }
        public string City { get; set; }
        public double Price { get;set; }
        public double EstateArea { get; set; }
        public int GenreId { get; set; }
        public int CategoryId { get; set; }
        public int StateId { get; set; }
    }
}
