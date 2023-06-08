using Application.UnitTests.Common;
using RealEstate.Application.Estates.Queries.GetEstateDetail;
using RealEstate.Application.Estates.Queries.GetEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Estate.Queries.GetEstateDetail
{
    public class GetEstateDetailQueryHandlerTests : CommandTestBase
    {
        private readonly GetEstateDetailQueryHandler _handler;

        public GetEstateDetailQueryHandlerTests() : base()
        {
            _handler = new GetEstateDetailQueryHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldGetEstateDetailId1()
        {
            var query = new GetEstateDetailQuery() { EstateId = 1 };

            await _handler.Handle(query, CancellationToken.None);
        }
    }
}
