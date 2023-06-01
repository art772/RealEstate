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

            var estate = new RealEstate.Domain.Entities.Estate() { 
                Id = 2,
                Name = "Mieszkanie 80m2, Polna 111, Poznań",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris malesuada nec sapien nec sollicitudin. Cras a metus nec nibh ultrices fringilla. Curabitur pellentesque viverra pellentesque. Nam mauris diam, accumsan a augue et, euismod ornare nibh. Quisque tortor risus, mattis ut arcu ac, sagittis posuere mi. Vivamus dui nunc, placerat eget lacus vitae, mollis porta augue. Ut est nibh, posuere eu nisl vel, efficitur faucibus elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nullam egestas quam in tortor fringilla lobortis sed quis eros. Etiam vel felis vel nisi condimentum hendrerit. Morbi vitae tellus quis elit posuere vestibulum. Proin varius diam vitae massa tristique, id mattis nunc pellentesque. Nullam posuere a orci consequat luctus. Vestibulum ut ullamcorper velit.\r\n\r\n",
                Street = "Polna",
                StreetNumber = "111",
                FlatNumber = "1",
                City = "Poznań",
                ZipCode = "60-123",
                Country = "Poland",
                Price = 500000.00,
                EstateArea = 80.00,
                YearOfConstruction = 2023
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
