using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Estates.Commands.RestoreEstate;

namespace RealEstate.Controllers.Admin
{
    [Route("api/admin/estates")]
    [Authorize(Roles = "SuperAdministrator,Administrator")]
    public class EstatesController : BaseController
    {
        [HttpPatch]
        public async Task<int> RestoreEstate(RestoreEstateCommand command)
        {
            await Mediator.Send(command);

            return command.EstateId;
        }
    }
}
