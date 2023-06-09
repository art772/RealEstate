using Application.UnitTests.Common;
using RealEstate.Application.Estates.Queries.GetEstateDetail;
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
        public async Task Handle_GivenValidRequest_ShouldGetEstateDetailId()
        {
            var query = new GetEstateDetailQuery() { EstateId = 88 };

            await _handler.Handle(query, CancellationToken.None);
        }
    }
}
