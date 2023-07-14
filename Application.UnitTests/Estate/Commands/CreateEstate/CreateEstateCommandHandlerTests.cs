using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Estates.Commands.CreateEstate;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Estate.Commands.CreateEstate
{
    public class CreateEstateCommandHandlerTests : CommandTestBase
    {
        private readonly CreateEstateCommandHandler _handler;

        public CreateEstateCommandHandlerTests() : base()
        {
            //_handler = new CreateEstateCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertEstate()
        {
            var command = new CreateEstateCommand()
            {
                Name = "Dom 150m2, Naramowice 15, Poznań",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris malesuada nec sapien nec sollicitudin. Cras a metus nec nibh ultrices fringilla.",
                Street = "Naramowicka",
                StreetNumber = "15",
                FlatNumber = "",
                City = "Poznań",
                ZipCode = "60-987",
                Country = "Poland",
                Price = 1500000.00,
                EstateArea = 150.00,
                YearOfConstruction = 2000
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var estate = await _context.Estates.FirstAsync(x => x.Id == result, CancellationToken.None);

            estate.ShouldNotBeNull();
        }
    }
}