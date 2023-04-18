using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Estates.Queries.GetEstateDetail;

namespace RealEstate.Controllers
{
    [Route("api/estates")]
    public class EstatesController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<EstateDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetEstateDetailQuery() { EstateId = id });
            return vm;
        }
    }
}
