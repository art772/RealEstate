using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Admin.Queries.GetCategories;
using RealEstate.Application.Categories.Commands.CreateCategory;

namespace RealEstate.Controllers.Category
{
    [Route("api/categories/[action]")]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await Mediator.Send(new GetCategoriesQuery()));
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> EditCategory(int id)
        {
            return Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> UpdateCategory()
        {
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok();
        }
    }
}
