using Microsoft.EntityFrameworkCore;
using Moq;
using RealEstate.Application.Common.Interfaces;
using RealEstate.Domain.Entities;
using RealEstate.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public static class EstateDbContextFactory
    {
        public static Mock<EstateDbContext> Create()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var options = new DbContextOptionsBuilder<EstateDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mock = new Mock<EstateDbContext>(options, dateTimeMock.Object) { CallBase = true };

            var context = mock.Object;

            context.Database.EnsureCreated();

            var category = new Category() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 3, Name = "Wynajem krótkoteminowy" };

            context.Categories.Add(category);

            var genre = new Genre() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 9, Name = "Działka budowlana" };

            context.Genres.Add(genre);

            var state = new State() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 6, Name = "Nieokreślone" };

            context.States.Add(state);

            var tag = new Tag() { CreatedBy = "art772", StatusId = 1, CreatedDate = DateTime.Now, Id = 6, Name = "Balkon" };

            context.Tags.Add(tag);

            var estate = new RealEstate.Domain.Entities.Estate()
            {
                CreatedBy = "art772",
                StatusId = 1,
                CreatedDate = DateTime.Now,
                Id = 2,
                Name = "Mieszkanie 80m2, Polna 111, Poznań",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris malesuada nec sapien nec sollicitudin. Cras a metus nec nibh ultrices fringilla.",
                Street = "Polna",
                StreetNumber = "111",
                FlatNumber = "1",
                City = "Poznań",
                ZipCode = "60-123",
                Country = "Poland",
                Price = 500000.00,
                EstateArea = 80.00,
                YearOfConstruction = 2023,
                CategoryId = 3,
                GenreId = 9,
                StateId = 6
            };

            context.Estates.Add(estate);

            context.SaveChanges();

            return mock;
        }

        public static void Destroy(EstateDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
