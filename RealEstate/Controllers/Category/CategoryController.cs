using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Categories.Commands.CreateCategory;

namespace RealEstate.Controllers.Category
{
    [Route("api/categories/[action]")]
    [Authorize(Roles = "SuperAdministrator,Administrator")]
    public class CategoryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCategory()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok();
        }
    }
}
