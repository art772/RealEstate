using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Admin.Queries.GetCategories;
using RealEstate.Application.Categories.Commands.CreateCategory;
using RealEstate.Application.Categories.Commands.DeleteCategory;
using RealEstate.Application.Categories.Commands.RestoreCategory;
using RealEstate.Application.Categories.Commands.UpdateCategory;
using RealEstate.Application.Categories.Queries.GetCategoryToEdit;

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
        //[Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> EditCategory(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryToEditQuery() { CategoryId = id }));
        }

        [HttpPatch]
        //[Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        //[Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryCommand() { CategoryId = id }));
        }

        [HttpPatch]
        //[Authorize(Roles = "SuperAdministrator,Administrator")]
        public async Task<IActionResult> RestoreCategory(RestoreCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
