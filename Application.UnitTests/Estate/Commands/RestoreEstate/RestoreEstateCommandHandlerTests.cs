using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Estates.Commands.RestoreEstate;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Estate.Commands.RestoreEstate
{
    public class RestoreEstateCommandHandlerTests : CommandTestBase
    {
        private readonly RestoreEstateCommandHandler _handler;

        public RestoreEstateCommandHandlerTests() : base()
        {
            _handler = new RestoreEstateCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldRestoreEstate()
        {
            var command = new RestoreEstateCommand()
            {
                EstateId = 2
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var estate = await _context.Estates.FirstAsync(x => x.Id == result, CancellationToken.None);

            estate.ShouldNotBeNull();
        }
    }
}
