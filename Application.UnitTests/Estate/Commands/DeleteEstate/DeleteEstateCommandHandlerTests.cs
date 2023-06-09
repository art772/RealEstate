using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Estates.Commands.DeleteEstate;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Estate.Commands.DeleteEstate
{
    public class DeleteEstateCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteEstateCommandHandler _handler;

        public DeleteEstateCommandHandlerTests() : base()
        {
            _handler = new DeleteEstateCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteEstate()
        {
            var command = new DeleteEstateCommand()
            {
                EstateId = 88
            };

            await _handler.Handle(command, CancellationToken.None);
        }
    }
}
