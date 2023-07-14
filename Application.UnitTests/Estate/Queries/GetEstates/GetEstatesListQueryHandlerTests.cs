using Application.UnitTests.Common;
using RealEstate.Application.Estates.Queries.GetEstates;
using Xunit;

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