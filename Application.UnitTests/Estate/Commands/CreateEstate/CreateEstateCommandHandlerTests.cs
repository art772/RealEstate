using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Estates.Commands.CreateEstate;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Estate.Commands.CreateEstate
{
    public class CreateEstateCommandHandlerTests : CommandTestBase
    {
        private readonly CreateEstateCommandHandler _handler;

        public CreateEstateCommandHandlerTests() : base()
        {
            _handler = new CreateEstateCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertEstate()
        {
            var command = new CreateEstateCommand()
            {
                // Dane nowej nieruchomości - nazwa, cena, itd..
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var estate = await _context.Estates.FirstAsync(x => x.Id == result, CancellationToken.None);

            estate.ShouldNotBeNull();
        }
    }
}
