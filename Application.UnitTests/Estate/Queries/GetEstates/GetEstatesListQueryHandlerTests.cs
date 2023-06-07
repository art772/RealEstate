using Application.UnitTests.Common;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Estates.Queries.GetEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.UnitTests.Estate.Queries.GetEstates
{
    public class GetEstatesListQueryHandlerTests : CommandTestBase
    {
        private readonly GetEstatesListQueryHandler _handler;

        public GetEstatesListQueryHandlerTests() : base()
        {
            _handler = new GetEstatesListQueryHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldGetEstatesList()
        {
            var query = new GetEstatesListQuery();

            await _handler.Handle(query, CancellationToken.None);
        }
    }
}
